$ErrorActionPreference = "Stop"

$Script:PackFolder = $PSScriptRoot
$Script:RootFolder = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
$Script:ProjectPath = Join-Path $Script:RootFolder "WebpowerX.Client\WebpowerX.Client.csproj"
$Script:OutputFolder = Join-Path $Script:RootFolder "artifacts\packages"

function Write-Info {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Message
    )

    Write-Host $Message -ForegroundColor Green
}

function Write-Step {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Message
    )

    Write-Host "`n==> $Message" -ForegroundColor Cyan
}

function Assert-FileExists {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Path
    )

    if (-not (Test-Path $Path -PathType Leaf)) {
        throw "File not found: $Path"
    }
}

function Invoke-CommandChecked {
    param(
        [Parameter(Mandatory = $true)]
        [string]$FilePath,

        [Parameter(Mandatory = $true)]
        [string[]]$Arguments
    )

    & $FilePath @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "Command failed with exit code ${LASTEXITCODE}: $FilePath $($Arguments -join ' ')"
    }
}

function Get-PackageVersion {
    param(
        [string]$Version
    )

    if (-not [string]::IsNullOrWhiteSpace($Version)) {
        return $Version
    }

    [xml]$projectXml = Get-Content $Script:ProjectPath
    $projectVersion = $projectXml.Project.PropertyGroup.Version
    if ([string]::IsNullOrWhiteSpace($projectVersion)) {
        throw "Package version is missing. Pass -Version or set <Version> in WebpowerX.Client.csproj."
    }

    return $projectVersion.Trim()
}

function Get-PackagePath {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Version
    )

    return Join-Path $Script:OutputFolder "WebpowerX.Client.$Version.nupkg"
}

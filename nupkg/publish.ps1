param(
    [string]$Version,
    [string]$ApiKey = $env:NUGET_API_KEY,
    [string]$Source = "https://api.nuget.org/v3/index.json",
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",
    [switch]$SkipDuplicate,
    [switch]$NoRestore
)

. "$PSScriptRoot\common.ps1"

if ([string]::IsNullOrWhiteSpace($ApiKey)) {
    throw "NuGet API key is missing. Pass -ApiKey or set NUGET_API_KEY."
}

$packageVersion = Get-PackageVersion -Version $Version

& "$PSScriptRoot\pack.ps1" -Version $packageVersion -Configuration $Configuration -NoRestore:$NoRestore
if ($LASTEXITCODE -ne 0) {
    throw "Package creation failed."
}

$packagePath = Get-PackagePath -Version $packageVersion
Assert-FileExists $packagePath

$pushArguments = @("nuget", "push", $packagePath, "--api-key", $ApiKey, "--source", $Source)
if ($SkipDuplicate) {
    $pushArguments += "--skip-duplicate"
}

Write-Step "Publishing $packagePath"
Invoke-CommandChecked "dotnet" $pushArguments
Write-Info "Package published: WebpowerX.Client $packageVersion"

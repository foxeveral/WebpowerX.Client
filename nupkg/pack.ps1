param(
    [string]$Version,
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",
    [switch]$NoRestore
)

. "$PSScriptRoot\common.ps1"

Assert-FileExists $Script:ProjectPath
$packageVersion = Get-PackageVersion -Version $Version

Write-Step "Cleaning package output"
New-Item -ItemType Directory -Force -Path $Script:OutputFolder | Out-Null
Remove-Item (Join-Path $Script:OutputFolder "*.nupkg") -Force -ErrorAction SilentlyContinue
Remove-Item (Join-Path $Script:OutputFolder "*.snupkg") -Force -ErrorAction SilentlyContinue

if (-not $NoRestore) {
    Write-Step "Restoring"
    Invoke-CommandChecked "dotnet" @("restore", $Script:ProjectPath)
}

Write-Step "Building"
Invoke-CommandChecked "dotnet" @("build", $Script:ProjectPath, "-c", $Configuration, "--no-restore")

Write-Step "Packing WebpowerX.Client $packageVersion"
Invoke-CommandChecked "dotnet" @(
    "pack",
    $Script:ProjectPath,
    "-c", $Configuration,
    "--no-build",
    "-o", $Script:OutputFolder,
    "/p:PackageVersion=$packageVersion"
)

$packagePath = Get-PackagePath -Version $packageVersion
Assert-FileExists $packagePath
Write-Info "Package created: $packagePath"

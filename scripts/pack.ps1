
param(
    [string] $Version,
    [string] $ApiKey,
    [string] $Configuration = "Release"
)

$RootFolder = Get-Location;
$ProjectName = Get-ChildItem -Path "$RootFolder/src" -File -Filter "*.slnx" | Select-Object -First 1 -ExpandProperty BaseName
$NugetPackageFolder = "$RootFolder/ci/Packages"
$NugetPackageFilePath = "$NugetPackageFolder/$ProjectName.$Version.nupkg"

try
{
    dotnet pack "$RootFolder/src/$ProjectName/$ProjectName.csproj" `
        --configuration $Configuration `
        --output $NugetPackageFolder `
        /p:Version=$Version

    Write-Host "`e[32m✅ Success:`e[0m Build completed successfully!"

    dotnet nuget push $NugetPackageFilePath `
        --api-key $ApiKey `
        --source https://api.nuget.org/v3/index.json
}
catch
{
    Write-Host "`e[31m❌ Error:`e[0m Something went wrong!"
    exit $LASTEXITCODE
}

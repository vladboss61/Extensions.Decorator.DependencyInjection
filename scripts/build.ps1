
$RootFolder = Get-Location;
$ProjectName = Get-ChildItem -Path "$RootFolder/src" -File -Filter "*.slnx" | Select-Object -First 1 -ExpandProperty BaseName

Write-Output "::group::🧱 Building project $ProjectName"

try
{
    dotnet restore "$RootFolder/src/$ProjectName/$ProjectName.csproj"
    dotnet build "$RootFolder/src/$ProjectName/$ProjectName.csproj" --configuration Release
    Write-Host "`e[32m✅ Success:`e[0m Build completed successfully!"

    Write-Host "`e[32m🚀 Publishing:`e[0m Publishing project to CI Binaries folder..."
    dotnet publish "$RootFolder/src/$ProjectName/$ProjectName.csproj" --configuration Release --no-build --output "$PSScriptRoot/../ci/Binaries/$ProjectName"
}
catch
{
    Write-Host "`e[31m❌ Error:`e[0m Something went wrong!"
    exit $LASTEXITCODE
}

Write-Output "::endgroup::"
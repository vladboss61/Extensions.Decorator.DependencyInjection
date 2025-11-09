
param(
    $Configuration = "Release"
)

$RootFolder = Get-Location;
$ProjectName = Get-ChildItem -Path "$RootFolder/src" -File -Filter "*.slnx" | Select-Object -First 1 -ExpandProperty BaseName
$BinariesOutputFolder = "$RootFolder/ci/Binaries/$ProjectName"

Write-Output "::group::🧱 Building project $ProjectName"

try
{
    dotnet restore "$RootFolder/src/$ProjectName/$ProjectName.csproj"
    dotnet build "$RootFolder/src/$ProjectName/$ProjectName.csproj" --configuration $Configuration
    Write-Host "`e[32m✅ Success:`e[0m Build completed successfully!"

    Write-Host "`e[32m🚀 Publishing:`e[0m Publishing project to CI Binaries folder..."
    dotnet publish "$RootFolder/src/$ProjectName/$ProjectName.csproj" `
        --configuration $Configuration --no-build `
        --output $BinariesOutputFolder
}
catch
{
    Write-Host "`e[31m❌ Error:`e[0m Something went wrong!"
    exit $LASTEXITCODE
}

Write-Output "::endgroup::"
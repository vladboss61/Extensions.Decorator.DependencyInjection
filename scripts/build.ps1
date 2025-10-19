$ProjectNameDir = Split-Path (Split-Path $PSScriptRoot -Parent) -Leaf

Write-Output "::group::🧱 Building project $ProjectNameDir"
Push-Location $ProjectNameDir

try
{
    dotnet restore "$ProjectNameDir.slnx"
    dotnet build "$ProjectNameDir.slnx" --configuration Release
    Write-Host "`e[32m✅ Success:`e[0m Build completed successfully!"


    Write-Host "`e[32m🚀 Publishing:`e[0m Publishing project to CI Binaries folder..."
    dotnet publish --configuration Release --runtime linux-x64 --no-build --output "$PSScriptRoot/../ci/Binaries/${ProjectNameDir}"
}
catch
{
    Write-Host "`e[31m❌ Error:`e[0m Something went wrong!"
}
finally
{
    Pop-Location
}

Write-Output "::endgroup::"
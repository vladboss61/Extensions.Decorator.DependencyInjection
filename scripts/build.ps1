$ProjectNameDir = Split-Path (Split-Path $PSScriptRoot -Parent) -Leaf

Write-Output "::group::🧱 Building project"

Write-Host "Building project name: $ProjectNameDir"
Push-Location $ProjectNameDir

try
{
    dotnet restore "$ProjectNameDir.sln"
    dotnet build "$ProjectNameDir.sln" --configuration Release
    Write-Host "`e[32m✅ Success:`e[0m Build completed successfully!"
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
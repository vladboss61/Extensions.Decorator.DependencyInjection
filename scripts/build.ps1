$ProjectName = Split-Path (Split-Path $PSScriptRoot -Parent) -Leaf

Write-Output "::group::🧱 Building project"

Write-Host "Building project name: $ProjectName"
Push-Location $PSScriptRoot

try
{
    dotnet restore "$ProjectName.sln"
    dotnet build "$ProjectName.sln" --configuration Release
    Write-Host "`e[32m✅ Success:`e[0m Build completed successfully!"
}
finally
{
    Write-Host "`e[31m❌ Error:`e[0m Something went wrong!"
    Pop-Location
}

Write-Output "::endgroup::"
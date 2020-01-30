
Write-Host "Restoring"
dotnet restore

Write-Host "Building"
dotnet build -c Release

Write-Host "Packing"
dotnet pack ./R6Stats/R6Stats.csproj -c Release

Write-Host "Collecting"
Copy-Item -Path "R6Stats/bin/Release/*" -Recurse -Destination "Artifacts/" -Force
Get-ChildItem -Path "Artifacts"
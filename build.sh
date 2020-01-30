echo "Restoring"
dotnet restore

echo "Building..."
dotnet build -c Release

echo "Packing..."
dotnet pack ./R6Stats/R6Stats.csproj -c Release

echo "Collecting..."
mkdir ./artifacts
cp -r ./R6Stats/bin/Release/* ./artifacts/

echo "Artifacts:"
cd ./artifacts
ls
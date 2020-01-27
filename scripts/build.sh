
#!/bin/bash

set -e

cd ./src
dotnet clean
dotnet restore
dotnet build
tsc ./Site/ts/main.ts --outDir ./Site/js/
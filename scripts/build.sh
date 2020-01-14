
#!/bin/bash

set -e

cd ./src
dotnet clean
dotnet restore
dotnet build
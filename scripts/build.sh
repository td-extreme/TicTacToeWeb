#!/bin/bash

set -e

cd ./src
dotnet clean
dotnet restore
dotnet build

cd ./Site/ts
../../../node_modules/typescript/bin/tsc game.ts main.ts --outFile ../js/main.js
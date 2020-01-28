#!/bin/bash

set -e

./node_modules/typescript/bin/tsc

cd ./src
dotnet clean
dotnet restore
dotnet build
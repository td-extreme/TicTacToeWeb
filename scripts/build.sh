#!/bin/bash

set -e

$(npm bin)/webpack

cd ./src
dotnet clean
dotnet restore
dotnet build
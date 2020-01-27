#!/bin/bash

set -e

$(npm bin)/mocha ./src/Site.Tests --reporter dot
cd ./src
dotnet test
exit 0

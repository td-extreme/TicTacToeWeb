#!/bin/bash

set -e

npm test ./src/Site.Tests
cd ./src
dotnet test
exit 0

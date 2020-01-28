#!/bin/bash

set -e

npm run test

cd ./src
dotnet test
exit 0

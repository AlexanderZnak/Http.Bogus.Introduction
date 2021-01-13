#!/bin/bash
# Running dotnet tests
dotnet test */CDListingTests.csproj --logger "trx;LogFileName=test-results.trx" --logger "console;verbosity=q"

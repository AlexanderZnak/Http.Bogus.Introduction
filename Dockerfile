 FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.10 as base
 WORKDIR /app
 FROM mcr.microsoft.com/dotnet/sdk:3.1
 WORKDIR /build
 COPY *.sln .
 COPY ./CDListingTests ./CDListingTests
 RUN dotnet test */CDListingTests.csproj --logger "trx;LogFileName=test-results.trx" --logger "console;verbosity=q"


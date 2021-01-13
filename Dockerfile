FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.10 as base
WORKDIR /app

#Create an intermediary container to build 
FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /build

#Copy a project solution file
COPY *.sln .

#Copy project files
COPY ./CDListingTests ./CDListingTests

#Copy a shell script for dotnet tests running 
COPY bin/run.sh . 

ENTRYPOINT ["./run.sh"]

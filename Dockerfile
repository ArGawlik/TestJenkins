# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
RUN mkdir src

copy . ./src
workdir /src
run dotnet restore
workdir /src/TestProject1/
run dotnet test --logger:"trx;LogFileName=C:\Temp\TestResults.xml" MyLibraryToTest.dll

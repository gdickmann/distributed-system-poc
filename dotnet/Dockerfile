# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build-env
WORKDIR /src
COPY . .

RUN dotnet restore ./A3/A3/A3.csproj
RUN dotnet publish ./A3/A3/A3.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "A3.dll"]
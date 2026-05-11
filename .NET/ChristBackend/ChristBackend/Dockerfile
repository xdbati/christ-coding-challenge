FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Restore
COPY ["ChristBackend.csproj", "."]
RUN dotnet restore 'ChristBackend.csproj'

# Build
COPY . .
RUN dotnet build 'ChristBackend.csproj' -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish 'ChristBackend.csproj' -c Release -o /app/publish

# Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChristBackend.dll"]

# Base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

COPY ["../../PinePaste.sln", "./"]
COPY ["./src/PinePaste.Api/PinePaste.Api.csproj", "./src/PinePaste.Api/"]
COPY ["./src/PinePaste.Application/PinePaste.Application.csproj", "./src/PinePaste.Application/"]
COPY ["./src/PinePaste.Core/PinePaste.Core.csproj", "./src/PinePaste.Core/"]
COPY ["./src/PinePaste.Domain/PinePaste.Domain.csproj", "./src/PinePaste.Domain/"]
COPY ["./src/PinePaste.Infrastructure/PinePaste.Infrastructure.csproj", "./src/PinePaste.Infrastructure/"]
RUN dotnet restore ./src/PinePaste.Api/PinePaste.Api.csproj

COPY ["./src", "./src/"]
WORKDIR /app/src/PinePaste.Api
RUN dotnet build "./PinePaste.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "./PinePaste.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PinePaste.Api.dll"]
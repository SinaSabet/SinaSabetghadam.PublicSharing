#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PublicSharing.Api/PublicSharing.Api.csproj", "PublicSharing.Api/"]
COPY ["PublicSharing.Infrastructure.Persistence/PublicSharing.Infrastructure.Persistence.csproj", "PublicSharing.Infrastructure.Persistence/"]
COPY ["PublicSharing.Domain/PublicSharing.Domain.csproj", "PublicSharing.Domain/"]
COPY ["PublicSharing.Infrastructure/PublicSharing.Infrastructure.csproj", "PublicSharing.Infrastructure/"]
COPY ["PublicSharing.Application/PublicSharing.Application.csproj", "PublicSharing.Application/"]
RUN dotnet restore "./PublicSharing.Api/PublicSharing.Api.csproj"
COPY . .
WORKDIR "/src/PublicSharing.Api"
RUN dotnet build "./PublicSharing.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PublicSharing.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PublicSharing.Api.dll"]
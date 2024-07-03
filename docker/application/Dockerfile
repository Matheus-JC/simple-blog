FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY SimpleBlog.sln .
COPY src/SimpleBlog.Api/SimpleBlog.Api.csproj src/SimpleBlog.Api/
COPY src/SimpleBlog.Application/SimpleBlog.Application.csproj src/SimpleBlog.Application/
COPY src/SimpleBlog.Infrastructure/SimpleBlog.Infrastructure.csproj src/SimpleBlog.Infrastructure/
COPY src/SimpleBlog.Domain/SimpleBlog.Domain.csproj src/SimpleBlog.Domain/
RUN dotnet restore
COPY ./src ./src
RUN dotnet build src/SimpleBlog.Api/SimpleBlog.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Docker
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleBlog.Api.dll"]
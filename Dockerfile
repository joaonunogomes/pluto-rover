FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# Copy all assets
COPY assets ./assets

# Build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY . .
RUN dotnet restore DotNetCoreBoilerplateApi.sln

# Publish
RUN mkdir - p /app
RUN dotnet publish "src/Presentation/Presentation.Api.csproj" -c Release -o /app --no-restore

# Unit Tests
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS unit-tests
USER root
ENV ASPNETCORE_ENVIRONMENT "Development"
WORKDIR /src
RUN mkdir -p /test-results
COPY --from=build /src .
COPY --from=build /root/.nuget /root/.nuget
RUN dotnet test DotNetCoreBoilerplateApi.sln

# Run api
FROM base AS final
ARG RUN_ENV="Development"
WORKDIR /app
COPY --from=build /app .

ENV SERVICE_PORT 9199
ENV ASPNETCORE_ENVIRONMENT ${RUN_ENV}
ENTRYPOINT ["dotnet", "DotNetCoreBoilerplateApi.Presentation.Api.dll"]

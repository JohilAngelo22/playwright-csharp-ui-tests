# Use the official .NET SDK image for building and running tests
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY playwright-csharp-ui-tests/*.csproj ./playwright-csharp-ui-tests/
RUN dotnet restore

# Copy the rest of the source code
COPY playwright-csharp-ui-tests/. ./playwright-csharp-ui-tests/

WORKDIR /app/playwright-csharp-ui-tests

# Install Playwright browsers
RUN dotnet tool install --global Microsoft.Playwright.CLI \
    && export PATH="$PATH:/root/.dotnet/tools" \
    && playwright install

# Build and run tests
ENTRYPOINT ["dotnet", "test"]
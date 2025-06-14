FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

RUN apt-get update -q && \
    apt-get install -y -qq --no-install-recommends \
        xvfb \
        libxcomposite1 \
        libxdamage1 \
        libatk1.0-0 \
        libasound2 \
        libdbus-1-3 \
        libnspr4 \
        libgbm1 \
        libatk-bridge2.0-0 \
        libcups2 \
        libxkbcommon0 \
        libatspi2.0-0 \
        libnss3 \
        libpango-1.0-0 \
        libcairo2 \
        libxrandr2

WORKDIR /app

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet build

RUN dotnet tool install --global Microsoft.Playwright.CLI
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN playwright install chromium

CMD dotnet test --logger "console;verbosity=detailed"

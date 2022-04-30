FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base

WORKDIR /app
EXPOSE 7047
EXPOSE 5047

ENV ASPNETCORE_URLS=https://+:7047;http://+:5047
ENV ASPNETCORE_ENVIRONMENT=Development

COPY . .

WORKDIR /app/pmBudget.API
RUN dotnet restore
RUN dotnet dev-certs https

ENTRYPOINT [ "dotnet", "watch", "run", "--no-restore"]
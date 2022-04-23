FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 5047

ENV ASPNETCORE_URLS=http://+:5047
ENV ASPNETCORE_ENVIRONMENT=Development

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/pmBudget.API/pmBudget.API.csproj", "src/pmBudget.API/"]
RUN dotnet restore "src/pmBudget.API/pmBudget.API.csproj"
COPY . .
WORKDIR "/src/src/pmBudget.API"
RUN dotnet build "pmBudget.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pmBudget.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pmBudget.API.dll"]


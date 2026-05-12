# Stage 1 — Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy and restore
COPY TaskManager.Api/TaskManager.Api.csproj TaskManager.Api/
RUN dotnet restore TaskManager.Api/TaskManager.Api.csproj

# Copy everything and publish
COPY TaskManager.Api/ TaskManager.Api/
WORKDIR /src/TaskManager.Api
RUN dotnet publish -c Release -o /app/publish

# Stage 2 — Runtime image (much smaller than SDK)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "TaskManager.Api.dll"]
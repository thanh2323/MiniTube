# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files and restore as distinct layers
COPY ["scr/MiniYoutube.API/MiniYoutube.API.csproj", "scr/MiniYoutube.API/"]
COPY ["scr/MiniYoutube.Application/MiniYoutube.Application.csproj", "scr/MiniYoutube.Application/"]
COPY ["scr/MiniYoutube.Infrastructure/MiniYoutube.Infrastructure.csproj", "scr/MiniYoutube.Infrastructure/"]
COPY ["scr/MiniYoutube.Core/MiniYoutube.Core.csproj", "scr/MiniYoutube.Core/"]

RUN dotnet restore "scr/MiniYoutube.API/MiniYoutube.API.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/scr/MiniYoutube.API"
RUN dotnet build "MiniYoutube.API.csproj" -c Release -o /app/build

# Publish Stage
FROM build AS publish
RUN dotnet publish "MiniYoutube.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "MiniYoutube.API.dll"]

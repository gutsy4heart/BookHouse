# Multi-stage build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BookHouse.csproj", "./"]
RUN dotnet restore "BookHouse.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "BookHouse.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookHouse.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookHouse.dll"] 
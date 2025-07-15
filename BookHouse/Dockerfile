# Этап 1: Базовый образ для runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Внутренний порт приложения
EXPOSE 8080  
ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Этап 2: Сборка приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем только файлы проекта для кэширования слоев
COPY ["BookHouse.csproj", "./"]
RUN dotnet restore "BookHouse.csproj"

# Копируем все остальные файлы
COPY . .
RUN dotnet build "BookHouse.csproj" -c Release -o /app/build

# Установка EF Core Tools для миграций
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Этап 3: Публикация
FROM build AS publish
RUN dotnet publish "BookHouse.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Этап 4: Финальный образ
FROM base AS final
WORKDIR /app

# Создаем пользователя для безопасного запуска
RUN adduser --disabled-password --gecos '' appuser && \
    chown -R appuser:appuser /app
USER appuser

# Копируем опубликованные файлы
COPY --from=publish --chown=appuser:appuser /app/publish .

ENTRYPOINT ["dotnet", "BookHouse.dll"]
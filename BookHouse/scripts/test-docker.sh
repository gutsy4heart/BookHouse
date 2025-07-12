#!/bin/bash

echo "🐳 Тестирование Docker сборки для BookHouse API"

# Остановка существующих контейнеров
echo "📦 Остановка существующих контейнеров..."
docker-compose down

# Удаление старых образов
echo "🗑️ Удаление старых образов..."
docker rmi gutsy4heart/bookhouse-api 2>/dev/null || true

# Сборка образа
echo "🔨 Сборка Docker образа..."
docker build -t gutsy4heart/bookhouse-api .

if [ $? -eq 0 ]; then
    echo "✅ Образ успешно собран!"
    
    # Запуск с docker-compose
    echo "🚀 Запуск с docker-compose..."
    docker-compose up -d
    
    # Ожидание запуска
    echo "⏳ Ожидание запуска сервисов..."
    sleep 10
    
    # Проверка API
    echo "🔍 Проверка API..."
    curl -f http://localhost:5006/api/book
    
    if [ $? -eq 0 ]; then
        echo "✅ API работает корректно!"
        echo "🌐 Приложение доступно по адресам:"
        echo "   - API: http://localhost:5006/api/book"
        echo "   - Swagger: http://localhost:5006/swagger"
        echo "   - Adminer: http://localhost:8089"
    else
        echo "❌ API не отвечает"
    fi
else
    echo "❌ Ошибка сборки образа"
    exit 1
fi 
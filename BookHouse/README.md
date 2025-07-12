# BookHouse API

ASP.NET Core 8.0 Web API для управления книгами с PostgreSQL базой данных.

## 🚀 Быстрый старт с Docker

### Предварительные требования
- Docker
- Docker Compose

### Запуск приложения

1. **Клонируйте репозиторий:**
```bash
git clone <your-repo-url>
cd BookHouse
```

2. **Запустите с помощью Docker Compose:**
```bash
docker-compose up -d
```

3. **Откройте в браузере:**
- API: http://localhost:5006/api/book
- Swagger UI: http://localhost:5006/swagger
- Adminer (база данных): http://localhost:8089

### Остановка приложения
```bash
docker-compose down
```

## 🛠 Локальная разработка

### Предварительные требования
- .NET 8.0 SDK
- PostgreSQL

### Настройка базы данных
```bash
# Запуск PostgreSQL
sudo systemctl start postgresql

# Создание базы данных
sudo -u postgres createdb bookhouse

# Применение миграций
dotnet ef database update
```

### Запуск приложения
```bash
dotnet run
```

## 📚 API Endpoints

- `GET /api/book` - Получить все книги
- `GET /api/book/{id}` - Получить книгу по ID
- `POST /api/book` - Добавить новую книгу
- `PUT /api/book` - Обновить книгу
- `DELETE /api/book/{id}` - Удалить книгу

## 🔧 CI/CD

Проект настроен с GitHub Actions для автоматического деплоя:

### Автоматический деплой при push в master:
1. **Тестирование** - сборка и запуск unit тестов
2. **Сборка Docker образа** - создание и публикация образа в Docker Hub
3. **Деплой** - автоматическое обновление на сервере

### Ручной деплой:
- Перейдите в Actions → CI/CD for BookHouse project → Run workflow

### Настройка секретов в GitHub
Добавьте следующие секреты в настройках репозитория:
- `DOCKER_USERNAME` - ваш Docker Hub username
- `DOCKER_PASSWORD` - ваш Docker Hub password/token
- `AZURE_VM_HOST` - IP адрес вашего Azure VM
- `AZURE_VM_USERNAME` - username для SSH подключения
- `AZURE_VM_SSH_KEY` - приватный SSH ключ

## 🐳 Docker

### Сборка образа
```bash
docker build -t bookhouse-api .
```

### Запуск контейнера
```bash
docker run -p 5006:80 bookhouse-api
```

### Docker Compose сервисы
- **api** - ASP.NET Core приложение (порт 5006)
- **postgres** - PostgreSQL база данных
- **adminer** - веб-интерфейс для управления БД (порт 8089)

## 📝 Лицензия

MIT License 
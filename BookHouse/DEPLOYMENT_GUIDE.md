# 🚀 Руководство по деплою BookHouse API

## 📋 Что было настроено

### 1. Docker файлы
- ✅ `Dockerfile` - многоэтапная сборка ASP.NET Core приложения
- ✅ `docker-compose.yml` - оркестрация сервисов (API + PostgreSQL + Adminer)
- ✅ `.dockerignore` - исключение ненужных файлов из контекста

### 2. CI/CD Pipeline
- ✅ `.github/workflows/ci-cd.yml` - автоматический деплой при push в master
- ✅ Тестирование, сборка и публикация Docker образа
- ✅ Деплой на Azure VM через SSH

### 3. Конфигурация
- ✅ `appsettings.Production.json` - production настройки
- ✅ `README.md` - документация проекта
- ✅ `GITHUB_SETUP.md` - настройка GitHub Secrets

## 🐳 Локальное тестирование

### Быстрый старт
```bash
# Сборка и запуск
./scripts/test-docker.sh

# Или вручную
docker-compose up -d
```

### Доступные сервисы
- **API**: http://localhost:5006/api/book
- **Swagger**: http://localhost:5006/swagger
- **Adminer**: http://localhost:8089

## 🔧 Настройка GitHub Secrets

### Обязательные секреты
1. `DOCKER_USERNAME` - ваш Docker Hub username
2. `DOCKER_PASSWORD` - ваш Docker Hub access token
3. `AZURE_VM_HOST` - IP адрес Azure VM
4. `AZURE_VM_USERNAME` - SSH username
5. `AZURE_VM_SSH_KEY` - приватный SSH ключ

### Как добавить
1. GitHub репозиторий → Settings → Secrets and variables → Actions
2. "New repository secret" для каждого секрета

## 🚀 Автоматический деплой

### При push в master ветку
1. ✅ Сборка проекта
2. ✅ Запуск тестов
3. ✅ Сборка Docker образа
4. ✅ Публикация в Docker Hub
5. ✅ Деплой на Azure VM

### Ручной деплой
1. GitHub → Actions → "CI/CD for BookHouse project"
2. "Run workflow" → "Run workflow"

## 📦 Docker Compose сервисы

```yaml
services:
  api:           # ASP.NET Core приложение (порт 5006)
  postgres:      # PostgreSQL база данных
  adminer:       # Веб-интерфейс БД (порт 8089)
```

## 🔍 Мониторинг

### Логи контейнеров
```bash
docker-compose logs -f api
docker-compose logs -f postgres
```

### Статус сервисов
```bash
docker-compose ps
```

### Очистка
```bash
docker-compose down -v  # удалить volumes
docker system prune     # очистить неиспользуемые ресурсы
```

## 🛠 Устранение неполадок

### Проблемы с Docker
```bash
# Перезапуск Docker
sudo systemctl restart docker

# Проверка статуса
docker info
```

### Проблемы с базой данных
```bash
# Подключение к PostgreSQL
docker-compose exec postgres psql -U postgres -d bookhouse

# Проверка миграций
docker-compose exec api dotnet ef database update
```

### Проблемы с CI/CD
1. Проверьте GitHub Secrets
2. Проверьте логи в Actions
3. Убедитесь, что Azure VM доступна

## 📞 Поддержка

При возникновении проблем:
1. Проверьте логи: `docker-compose logs`
2. Проверьте статус: `docker-compose ps`
3. Перезапустите: `docker-compose restart` 
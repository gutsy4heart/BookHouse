# Настройка GitHub Secrets для CI/CD

## Необходимые секреты

Для работы CI/CD pipeline необходимо настроить следующие секреты в GitHub репозитории:

### 1. Docker Hub секреты
- `DOCKER_USERNAME` - ваш username в Docker Hub
- `DOCKER_PASSWORD` - ваш password или access token в Docker Hub

### 2. Azure VM секреты
- `AZURE_VM_HOST` - IP адрес вашего Azure VM
- `AZURE_VM_USERNAME` - username для SSH подключения к VM
- `AZURE_VM_SSH_KEY` - приватный SSH ключ для подключения

## Как добавить секреты

1. Перейдите в ваш GitHub репозиторий
2. Нажмите на вкладку "Settings"
3. В левом меню выберите "Secrets and variables" → "Actions"
4. Нажмите "New repository secret"
5. Добавьте каждый секрет по отдельности

## Получение Docker Hub токена

1. Войдите в Docker Hub
2. Перейдите в Account Settings → Security
3. Нажмите "New Access Token"
4. Дайте токену имя (например, "github-actions")
5. Скопируйте токен и используйте его как `DOCKER_PASSWORD`

## Настройка Azure VM

1. Создайте Azure VM с Ubuntu/Debian
2. Установите Docker и Docker Compose
3. Настройте SSH ключи
4. Создайте папку `/app` на VM
5. Убедитесь, что пользователь имеет права на выполнение Docker команд

## Тестирование

После настройки секретов:

1. Сделайте push в ветку `master` - запустится автоматический деплой
2. Или перейдите в Actions → "CI/CD for BookHouse project" → "Run workflow" для ручного деплоя

## Проверка деплоя

После успешного деплоя приложение будет доступно по адресу:
- API: `http://YOUR_VM_IP:5006/api/book`
- Swagger: `http://YOUR_VM_IP:5006/swagger`
- Adminer: `http://YOUR_VM_IP:8089` 
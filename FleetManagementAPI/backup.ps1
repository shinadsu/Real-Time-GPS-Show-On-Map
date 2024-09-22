# Параметры подключения
$DB_NAME = "LocationTracker"
$DB_USER = "sa"
$DB_PASSWORD = "mitsuru12345"
$DB_SERVER = "BAZASKUFA"
$BACKUP_PATH = "C:\db_backup\LocationTracker.bak"

# Создаем папку для бэкапов, если она не существует
if (!(Test-Path "C:\db_backup")) {
    New-Item -ItemType Directory -Path "C:\db_backup"
}

# Команда для создания дампа базы данных
$sqlCmd = "BACKUP DATABASE [$DB_NAME] TO DISK='$BACKUP_PATH' WITH FORMAT"

# Выполняем команду через sqlcmd
& sqlcmd -S $DB_SERVER -U $DB_USER -P $DB_PASSWORD -Q $sqlCmd

# Проверяем, был ли успешно создан бэкап
if (Test-Path $BACKUP_PATH) {
    Write-Host "База данных $DB_NAME успешно сохранена в $BACKUP_PATH"
} else {
    Write-Host "Ошибка при создании дампа базы данных!"
    exit 1
}

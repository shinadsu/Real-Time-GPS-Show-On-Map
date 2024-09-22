# ��������� �����������
$DB_NAME = "LocationTracker"
$DB_USER = "sa"
$DB_PASSWORD = "mitsuru12345"
$DB_SERVER = "BAZASKUFA"
$BACKUP_PATH = "C:\db_backup\LocationTracker.bak"

# ������� ����� ��� �������, ���� ��� �� ����������
if (!(Test-Path "C:\db_backup")) {
    New-Item -ItemType Directory -Path "C:\db_backup"
}

# ������� ��� �������� ����� ���� ������
$sqlCmd = "BACKUP DATABASE [$DB_NAME] TO DISK='$BACKUP_PATH' WITH FORMAT"

# ��������� ������� ����� sqlcmd
& sqlcmd -S $DB_SERVER -U $DB_USER -P $DB_PASSWORD -Q $sqlCmd

# ���������, ��� �� ������� ������ �����
if (Test-Path $BACKUP_PATH) {
    Write-Host "���� ������ $DB_NAME ������� ��������� � $BACKUP_PATH"
} else {
    Write-Host "������ ��� �������� ����� ���� ������!"
    exit 1
}

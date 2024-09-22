USE master;
IF DB_ID('LocationTracker') IS NOT NULL
BEGIN
    ALTER DATABASE [LocationTracker] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [LocationTracker];
END
RESTORE DATABASE [LocationTracker]
FROM DISK = '/var/opt/mssql/backup/LocationTracker.bak'
WITH REPLACE,
MOVE 'LocationTracker' TO '/var/opt/mssql/data/LocationTracker.mdf',
MOVE 'LocationTracker_log' TO '/var/opt/mssql/data/LocationTracker_log.ldf';
ALTER DATABASE [LocationTracker] SET MULTI_USER;

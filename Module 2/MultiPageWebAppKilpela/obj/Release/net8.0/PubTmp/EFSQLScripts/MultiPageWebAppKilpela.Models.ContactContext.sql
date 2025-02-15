IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130025143_Initial'
)
BEGIN
    CREATE TABLE [Contacts] (
        [ContactId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(10) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Note] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Contacts] PRIMARY KEY ([ContactId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130025143_Initial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ContactId', N'Address', N'Name', N'Note', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Contacts]'))
        SET IDENTITY_INSERT [Contacts] ON;
    EXEC(N'INSERT INTO [Contacts] ([ContactId], [Address], [Name], [Note], [PhoneNumber])
    VALUES (1, N''Japan'', N''Joji'', N''Favorite Artist'', N''123456789'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ContactId', N'Address', N'Name', N'Note', N'PhoneNumber') AND [object_id] = OBJECT_ID(N'[Contacts]'))
        SET IDENTITY_INSERT [Contacts] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250130025143_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250130025143_Initial', N'9.0.1');
END;

COMMIT;
GO


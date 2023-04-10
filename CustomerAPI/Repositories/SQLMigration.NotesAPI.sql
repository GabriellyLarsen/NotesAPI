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
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Note] (
    [Id] int NOT NULL IDENTITY,
    [CategoryId] int NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [TargetDate] datetime2 NOT NULL,
    [LastUpdateDate] datetime2 NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Note] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Note_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description') AND [object_id] = OBJECT_ID(N'[Category]'))
    SET IDENTITY_INSERT [Category] ON;
INSERT INTO [Category] ([Id], [Description])
VALUES (1, N'Work'),
(2, N'FamilyEvent'),
(3, N'Study'),
(4, N'General');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description') AND [object_id] = OBJECT_ID(N'[Category]'))
    SET IDENTITY_INSERT [Category] OFF;
GO

CREATE INDEX [IX_Note_CategoryId] ON [Note] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230409194922_Init', N'7.0.4');
GO

COMMIT;
GO


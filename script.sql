IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Posts] (
    [Id] int NOT NULL IDENTITY,
    [IsNewPost] bit NOT NULL,
    [CreatedDateTime] datetime2 NOT NULL,
    [EditedDateTime] datetime2 NOT NULL,
    [Title] nvarchar(max) NULL,
    [Body] nvarchar(max) NULL,
    [Tags] nvarchar(max) NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190117220710_init', N'2.1.4-rtm-31024');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Posts]') AND [c].[name] = N'IsNewPost');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Posts] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Posts] DROP COLUMN [IsNewPost];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190120071118_postmodel_update', N'2.1.4-rtm-31024');

GO

CREATE TABLE [ProfileData] (
    [ID] int NOT NULL IDENTITY,
    [ProfileName] nvarchar(max) NULL,
    [DescriptionBlurb] nvarchar(max) NULL,
    CONSTRAINT [PK_ProfileData] PRIMARY KEY ([ID])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190129114922_ProfileModel', N'2.1.4-rtm-31024');

GO



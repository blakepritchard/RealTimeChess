IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE TABLE [tblChessMatches] (
        [ChessMatchId] int NOT NULL IDENTITY,
        [Created] datetime2 NOT NULL,
        [Deleted] datetime2 NULL,
        [IsActive] bit NOT NULL,
        [IsDeleted] bit NOT NULL,
        [MatchEndTime] datetime2 NOT NULL,
        [MatchStartTime] datetime2 NOT NULL,
        [PlayerTypeName] nvarchar(max) NULL,
        [Updated] datetime2 NOT NULL,
        CONSTRAINT [PK_ChessMatches] PRIMARY KEY ([ChessMatchId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE TABLE [tblPlayers] (
        [PlayerId] int NOT NULL IDENTITY,
        [AuthenticationId] int NOT NULL,
        [Created] datetime2 NOT NULL,
        [Deleted] datetime2 NULL,
        [FirstName] nvarchar(max) NULL,
        [IsActive] bit NOT NULL,
        [IsDeleted] bit NOT NULL,
        [LastName] nvarchar(max) NULL,
        [NumLosses] int NOT NULL,
        [NumWins] int NOT NULL,
        [Updated] datetime2 NOT NULL,
        CONSTRAINT [PK_Players] PRIMARY KEY ([PlayerId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE TABLE [tblPlayerTypes] (
        [PlayerTypeId] int NOT NULL IDENTITY,
        [PlayerTypeName] nvarchar(max) NULL,
        [TurnOrder] int NOT NULL,
        CONSTRAINT [PK_PlayerTypes] PRIMARY KEY ([PlayerTypeId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE TABLE [tblMatchPlayers] (
        [MatchPlayerId] int NOT NULL IDENTITY,
        [ChessMatchId] int NOT NULL,
        [Created] datetime2 NOT NULL,
        [Deleted] datetime2 NULL,
        [IsDeleted] bit NOT NULL,
        [PlayerId] int NOT NULL,
        [PlayerTypeId] int NOT NULL,
        [Updated] datetime2 NOT NULL,
        CONSTRAINT [PK_MatchPlayers] PRIMARY KEY ([MatchPlayerId]),
        CONSTRAINT [FK_tblMatchPlayers_tblChessMatches_ChessMatchId] FOREIGN KEY ([ChessMatchId]) REFERENCES [tblChessMatches] ([ChessMatchId]) ON DELETE CASCADE,
        CONSTRAINT [FK_tblMatchPlayers_tblPlayers_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [tblPlayers] ([PlayerId]) ON DELETE CASCADE,
        CONSTRAINT [FK_tblMatchPlayers_tblPlayerTypes_PlayerTypeId] FOREIGN KEY ([PlayerTypeId]) REFERENCES [tblPlayerTypes] ([PlayerTypeId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE TABLE [tblMoves] (
        [MoveId] int NOT NULL IDENTITY,
        [AlgebraicChessNotation] nvarchar(max) NULL,
        [Created] datetime2 NOT NULL,
        [Deleted] datetime2 NULL,
        [GameClockBeginMove] datetime2 NOT NULL,
        [GameClockEndMove] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        [MatchPlayerId] int NOT NULL,
        [PlayerTypeName] nvarchar(max) NULL,
        [PositionBeginMove] nvarchar(max) NULL,
        [PositionEndMove] nvarchar(max) NULL,
        [Updated] datetime2 NOT NULL,
        CONSTRAINT [PK_Moves] PRIMARY KEY ([MoveId]),
        CONSTRAINT [FK_tblMoves_tblMatchPlayers_MatchPlayerId] FOREIGN KEY ([MatchPlayerId]) REFERENCES [tblMatchPlayers] ([MatchPlayerId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE INDEX [IX_tblMatchPlayers_ChessMatchId] ON [tblMatchPlayers] ([ChessMatchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE INDEX [IX_tblMatchPlayers_PlayerId] ON [tblMatchPlayers] ([PlayerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE INDEX [IX_tblMatchPlayers_PlayerTypeId] ON [tblMatchPlayers] ([PlayerTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    CREATE INDEX [IX_tblMoves_MatchPlayerId] ON [tblMoves] ([MatchPlayerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218004936_CreateChessSchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180218004936_CreateChessSchema', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180218032538_SeedPlayerTypes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180218032538_SeedPlayerTypes', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180225202902_ModelChessPieces')
BEGIN
    CREATE TABLE [tblChessPieces] (
        [ChessPieceId] int NOT NULL IDENTITY,
        [ChessPieceTypeId] int NOT NULL,
        [Destination] nvarchar(max) NULL,
        [Heading] real NOT NULL,
        [Location] nvarchar(max) NULL,
        [MatchPlayerId] int NOT NULL,
        [PositionX] real NOT NULL,
        [PositionY] real NOT NULL,
        [Velocity] real NOT NULL,
        CONSTRAINT [PK_ChessPieces] PRIMARY KEY ([ChessPieceId]),
        CONSTRAINT [FK_tblChessPieces_tblMatchPlayers_MatchPlayerId] FOREIGN KEY ([MatchPlayerId]) REFERENCES [tblMatchPlayers] ([MatchPlayerId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180225202902_ModelChessPieces')
BEGIN
    CREATE TABLE [tblChessPieceTypes] (
        [ChessPieceTypeId] int NOT NULL IDENTITY,
        [ChessPieceScoreValue] int NOT NULL,
        [ChessPieceTypeName] nvarchar(max) NULL,
        [ImagePath] nvarchar(max) NULL,
        [Velocity] int NOT NULL,
        CONSTRAINT [PK_ChessPieceTypes] PRIMARY KEY ([ChessPieceTypeId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180225202902_ModelChessPieces')
BEGIN
    CREATE INDEX [IX_tblChessPieces_MatchPlayerId] ON [tblChessPieces] ([MatchPlayerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180225202902_ModelChessPieces')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180225202902_ModelChessPieces', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180225222615_ChessMatchNumPlayers')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessMatches') AND [c].[name] = N'PlayerTypeName');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [tblChessMatches] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [tblChessMatches] DROP COLUMN [PlayerTypeName];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180225222615_ChessMatchNumPlayers')
BEGIN
    ALTER TABLE [tblChessMatches] ADD [NumPlayers] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180225222615_ChessMatchNumPlayers')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180225222615_ChessMatchNumPlayers', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180226001228_ChessMatchOptionalEndTime')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessMatches') AND [c].[name] = N'MatchEndTime');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [tblChessMatches] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [tblChessMatches] ALTER COLUMN [MatchEndTime] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180226001228_ChessMatchOptionalEndTime')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180226001228_ChessMatchOptionalEndTime', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180228000410_ChessPieceCoordinates')
BEGIN
    EXEC sp_rename N'tblChessPieces.Location', N'LocationFileLetter', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180228000410_ChessPieceCoordinates')
BEGIN
    EXEC sp_rename N'tblChessPieces.Destination', N'LocationCoordinates', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180228000410_ChessPieceCoordinates')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [DestinationCoordinates] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180228000410_ChessPieceCoordinates')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [IsMoving] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180228000410_ChessPieceCoordinates')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [LocationRankNum] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180228000410_ChessPieceCoordinates')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180228000410_ChessPieceCoordinates', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'LocationCoordinates');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [LocationCoordinates];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'LocationFileLetter');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [LocationFileLetter];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [ArrivalTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [DepartureTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [DestinationFileNum] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [DestinationRankNum] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [HeadingCos] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [HeadingSin] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [LocationFileNum] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301064927_ChessPieceCoordinateTypes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180301064927_ChessPieceCoordinateTypes', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301232331_ChessMatchStatusFlags')
BEGIN
    ALTER TABLE [tblChessMatches] ADD [HasStarted] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301232331_ChessMatchStatusFlags')
BEGIN
    ALTER TABLE [tblChessMatches] ADD [IsSetup] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301232331_ChessMatchStatusFlags')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180301232331_ChessMatchStatusFlags', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301233128_ChessPieceIsCaptured')
BEGIN
    ALTER TABLE [tblChessPieces] ADD [IsCaptured] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180301233128_ChessPieceIsCaptured')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180301233128_ChessPieceIsCaptured', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304015817_RefactoringMovesFromPlayerToPieces')
BEGIN
    ALTER TABLE [tblMoves] DROP CONSTRAINT [FK_tblMoves_tblMatchPlayers_MatchPlayerId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304015817_RefactoringMovesFromPlayerToPieces')
BEGIN
    EXEC sp_rename N'tblMoves.MatchPlayerId', N'ChessPieceId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304015817_RefactoringMovesFromPlayerToPieces')
BEGIN
    EXEC sp_rename N'tblMoves.IX_tblMoves_MatchPlayerId', N'IX_tblMoves_ChessPieceId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304015817_RefactoringMovesFromPlayerToPieces')
BEGIN
    ALTER TABLE [tblMoves] ADD CONSTRAINT [FK_tblMoves_tblChessPieces_ChessPieceId] FOREIGN KEY ([ChessPieceId]) REFERENCES [tblChessPieces] ([ChessPieceId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304015817_RefactoringMovesFromPlayerToPieces')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180304015817_RefactoringMovesFromPlayerToPieces', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'PlayerTypeName');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [tblMoves] DROP COLUMN [PlayerTypeName];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'PositionBeginMove');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [tblMoves] DROP COLUMN [PositionBeginMove];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'PositionEndMove');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [tblMoves] DROP COLUMN [PositionEndMove];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'ArrivalTime');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [ArrivalTime];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'DepartureTime');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [DepartureTime];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'DestinationCoordinates');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [DestinationCoordinates];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'DestinationFileNum');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [DestinationFileNum];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'DestinationRankNum');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [DestinationRankNum];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'Heading');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [Heading];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'HeadingCos');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [HeadingCos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'HeadingSin');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [HeadingSin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'PositionX');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [PositionX];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'PositionY');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [PositionY];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblChessPieces') AND [c].[name] = N'Velocity');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [tblChessPieces] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [tblChessPieces] DROP COLUMN [Velocity];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    EXEC sp_rename N'tblChessPieces.LocationRankNum', N'LocationY', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    EXEC sp_rename N'tblChessPieces.LocationFileNum', N'LocationX', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'GameClockEndMove');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [tblMoves] ALTER COLUMN [GameClockEndMove] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'GameClockBeginMove');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [tblMoves] ALTER COLUMN [GameClockBeginMove] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [Distance] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [Heading] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [HeadingCos] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [HeadingSin] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [PositionBeginX] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [PositionBeginY] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [PositionCurrentX] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [PositionCurrentY] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [PositionEndX] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [PositionEndY] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [TravelTime] time NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    ALTER TABLE [tblMoves] ADD [Velocity] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180304053617_RefactoringMoveParameters')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180304053617_RefactoringMoveParameters', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180308220040_LinkChessPieceTypeToChessPieces')
BEGIN
    CREATE INDEX [IX_tblChessPieces_ChessPieceTypeId] ON [tblChessPieces] ([ChessPieceTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180308220040_LinkChessPieceTypeToChessPieces')
BEGIN
    ALTER TABLE [tblChessPieces] ADD CONSTRAINT [FK_tblChessPieces_tblChessPieceTypes_ChessPieceTypeId] FOREIGN KEY ([ChessPieceTypeId]) REFERENCES [tblChessPieceTypes] ([ChessPieceTypeId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180308220040_LinkChessPieceTypeToChessPieces')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180308220040_LinkChessPieceTypeToChessPieces', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180309041055_FullyDefiningRelationshipToChessPieceType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180309041055_FullyDefiningRelationshipToChessPieceType', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180311200044_ChessMoveParametersOptional')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'Updated');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [tblMoves] ALTER COLUMN [Updated] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180311200044_ChessMoveParametersOptional')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'PositionBeginY');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [tblMoves] ALTER COLUMN [PositionBeginY] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180311200044_ChessMoveParametersOptional')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'PositionBeginX');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [tblMoves] ALTER COLUMN [PositionBeginX] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180311200044_ChessMoveParametersOptional')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'IsDeleted');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [tblMoves] ALTER COLUMN [IsDeleted] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180311200044_ChessMoveParametersOptional')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'GameClockBeginMove');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [tblMoves] ALTER COLUMN [GameClockBeginMove] datetime2 NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180311200044_ChessMoveParametersOptional')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'tblMoves') AND [c].[name] = N'Created');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [tblMoves] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [tblMoves] ALTER COLUMN [Created] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180311200044_ChessMoveParametersOptional')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180311200044_ChessMoveParametersOptional', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180315000001_WebCLientUrl')
BEGIN
    ALTER TABLE [tblMatchPlayers] ADD [WebClientUrl] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180315000001_WebCLientUrl')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180315000001_WebCLientUrl', N'2.0.1-rtm-125');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180315012752_OpponentPostOne')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180315012752_OpponentPostOne', N'2.0.1-rtm-125');
END;

GO


/****************************
 * GameTeam Table
 ****************************/
IF OBJECT_ID(N'Football.GameTeam') IS NULL
BEGIN
   CREATE TABLE Football.GameTeam
   (
      GameTeamId INT NOT NULL IDENTITY(1, 1), -- Primary Key (PK)
      TeamId INT NOT NULL,                    -- FK1, Composite Key
      GameId INT NOT NULL,                    -- FK2, Composite Key
      TeamTypeId INT NOT NULL,                -- FK3
      TopOfPossessionSec INT,
      Score INT,

      CONSTRAINT [PK_Football_GameTeam_GameTeamId] PRIMARY KEY CLUSTERED
      (
         GameTeamId ASC
      )
   );
END;

/****************************
 * Unique Constraints
 ****************************/

-- Unique Constraint U1: GameId and TeamTypeId
IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Football.GameTeam')
         AND kc.[name] = N'UK_Football_GameTeam_U1'
   )
BEGIN
   ALTER TABLE Football.GameTeam
   ADD CONSTRAINT [UK_Football_GameTeam_U1] UNIQUE NONCLUSTERED
   (
      GameId ASC,
      TeamTypeId ASC
   );
END;

-- Composite Unique Constraint U3: GameId and TeamId
IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Football.GameTeam')
         AND kc.[name] = N'UK_Football_GameTeam_GameId_TeamId'
   )
BEGIN
   ALTER TABLE Football.GameTeam
   ADD CONSTRAINT [UK_Football_GameTeam_GameId_TeamId] UNIQUE NONCLUSTERED
   (
      GameId ASC,
      TeamId ASC
   );
END;

/****************************
 * Foreign Keys Constraints
 ****************************/

-- Foreign Key to Football.Team
IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Football.GameTeam')
         AND fk.referenced_object_id = OBJECT_ID(N'Football.Team')
         AND fk.[name] = N'FK_Football_GameTeam_TeamId'
   )
BEGIN
   ALTER TABLE Football.GameTeam
   ADD CONSTRAINT [FK_Football_GameTeam_TeamId] FOREIGN KEY
   (
      TeamId
   )
   REFERENCES Football.Team
   (
      TeamId
   );
END;

-- Foreign Key to Football.Game
IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Football.GameTeam')
         AND fk.referenced_object_id = OBJECT_ID(N'Football.Game')
         AND fk.[name] = N'FK_Football_GameTeam_GameId'
   )
BEGIN
   ALTER TABLE Football.GameTeam
   ADD CONSTRAINT [FK_Football_GameTeam_GameId] FOREIGN KEY
   (
      GameId
   )
   REFERENCES Football.Game
   (
      GameId
   );
END;

-- Foreign Key to Football.TeamType
IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Football.GameTeam')
         AND fk.referenced_object_id = OBJECT_ID(N'Football.TeamType')
         AND fk.[name] = N'FK_Football_GameTeam_TeamTypeId'
   )
BEGIN
   ALTER TABLE Football.GameTeam
   ADD CONSTRAINT [FK_Football_GameTeam_TeamTypeId] FOREIGN KEY
   (
      TeamTypeId
   )
   REFERENCES Football.TeamType
   (
      TeamTypeId
   );
END;

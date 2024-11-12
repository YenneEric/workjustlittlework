IF OBJECT_ID(N'Football.Season') IS NULL
BEGIN
   CREATE TABLE Football.Season
   (
      SeasonId INT NOT NULL IDENTITY(1, 1),
      [Year] INT NOT NULL,

      CONSTRAINT [PK_Football_Season_SeasonId] PRIMARY KEY CLUSTERED
      (
         SeasonId ASC
      )
   );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Football.Season')
         AND kc.[name] = N'UK_Football_Season_Year'
   )
BEGIN
   ALTER TABLE Football.Season
   ADD CONSTRAINT [UK_Football_Season_Year] UNIQUE NONCLUSTERED
   (
      Year ASC
   )
END;

/****************************
 * Conference Table
 ****************************/
IF OBJECT_ID(N'Football.Conference') IS NULL
BEGIN
   CREATE TABLE Football.Conference
   (
      ConfId INT NOT NULL IDENTITY(1, 1),
      ConfName NVARCHAR(255) NOT NULL,

      CONSTRAINT [PK_Conference_ConfId] PRIMARY KEY CLUSTERED
      (
         ConfId ASC
      )
      
   );
END;

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Football.Conference')
         AND kc.[name] = N'UK_Conference_ConfName'
   )
BEGIN
   ALTER TABLE Football.Conference
   ADD CONSTRAINT [UK_Conference_ConfName] UNIQUE NONCLUSTERED
   (
      ConfName ASC
   )
END;
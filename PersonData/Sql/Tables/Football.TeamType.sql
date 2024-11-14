/****************************
 * TeamType Table
 ****************************/
IF OBJECT_ID(N'Football.TeamType') IS NULL
BEGIN
   CREATE TABLE Football.TeamType
   (
      TeamTypeId INT NOT NULL IDENTITY(1, 1), -- Primary Key (PK)
      Name NVARCHAR(255) NOT NULL,                      -- Must be either 1 or 2

      CONSTRAINT [PK_Football_TeamType_TeamTypeId] PRIMARY KEY CLUSTERED
      (
         TeamTypeId ASC
      )
   );
END;

/****************************
 * Check Constraints
 ****************************/

-- Ensure that Name is Home or Away
IF NOT EXISTS
   (
      SELECT *
      FROM sys.check_constraints cc
      WHERE cc.parent_object_id = OBJECT_ID(N'Football.TeamType')
         AND cc.[name] = N'CK_Football_TeamType_Name'
   )
   BEGIN
   ALTER TABLE Football.TeamType
   ADD CONSTRAINT CK_Football_TeamType_Name
   CHECK (Name IN (N'Home', N'Away'));
END;


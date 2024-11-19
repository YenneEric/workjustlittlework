
--select from the table teamtype all parameters are optional and a list based on those parms 



CREATE OR ALTER PROCEDURE Football.GetTeamType
    @TeamTypeId INT = NULL,
    @Name NVARCHAR(255) = NULL
AS
BEGIN
    SELECT *
    FROM Football.TeamType
    WHERE (@TeamTypeId IS NULL OR TeamTypeId = @TeamTypeId)
      AND (@Name IS NULL OR Name = @Name);
END;
GO

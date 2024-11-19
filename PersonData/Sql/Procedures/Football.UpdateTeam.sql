
--update on the table team where the id is required and rest are optional, 
--only updates the column if a new value is provided

CREATE OR ALTER PROCEDURE Football.UpdateTeam
    @TeamId INT, 
    @TeamName NVARCHAR(255) = NULL, 
    @Location NVARCHAR(255) = NULL, 
    @Mascot NVARCHAR(255) = NULL, 
    @ConfId INT = NULL 
AS
BEGIN
    
    UPDATE Football.Team
    SET 
        TeamName = COALESCE(@TeamName, TeamName),
        [Location] = COALESCE(@Location, [Location]),
        Mascot = COALESCE(@Mascot, Mascot),
        ConfId = COALESCE(@ConfId, ConfId)
    WHERE 
        TeamId = @TeamId;

   
END;
GO

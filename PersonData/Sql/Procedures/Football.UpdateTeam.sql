CREATE OR ALTER PROCEDURE Football.UpdateTeam
    @TeamId INT, -- ID of the team to update
    @TeamName NVARCHAR(255) = NULL, -- Optional: New team name
    @Location NVARCHAR(255) = NULL, -- Optional: New location
    @Mascot NVARCHAR(255) = NULL, -- Optional: New mascot
    @ConfId INT = NULL -- Optional: New conference ID
AS
BEGIN
    -- Update the team information
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

    
--select from the table teamplayer all parameters are optional and a list based on those parms 



CREATE OR ALTER PROCEDURE Football.GetTeamPlayer
    @PlayerId INT = NULL, 
    @SeasonId INT = NULL,
    @TeamId INT = NULL,   
    @JerseyNumber INT = NULL 
AS
BEGIN
    SELECT *
    FROM Football.TeamPlayer
    WHERE (@PlayerId IS NULL OR PlayerId = @PlayerId)
      AND (@SeasonId IS NULL OR SeasonId = @SeasonId)
      AND (@TeamId IS NULL OR TeamId = @TeamId)
      AND (@JerseyNumber IS NULL OR JerseyNumber = @JerseyNumber); 
END;
GO

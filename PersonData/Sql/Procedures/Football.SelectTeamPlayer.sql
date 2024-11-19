CREATE OR ALTER PROCEDURE Football.GetTeamPlayer
    @PlayerId INT = NULL, -- Optional filter for PlayerId
    @SeasonId INT = NULL, -- Optional filter for SeasonId
    @TeamId INT = NULL,   -- Optional filter for TeamId
    @JerseyNumber INT = NULL -- Optional filter for JerseyNumber
AS
BEGIN
    SELECT *
    FROM Football.TeamPlayer
    WHERE (@PlayerId IS NULL OR PlayerId = @PlayerId)
      AND (@SeasonId IS NULL OR SeasonId = @SeasonId)
      AND (@TeamId IS NULL OR TeamId = @TeamId)
      AND (@JerseyNumber IS NULL OR JerseyNumber = @JerseyNumber); -- Added JerseyNumber filter
END;
GO

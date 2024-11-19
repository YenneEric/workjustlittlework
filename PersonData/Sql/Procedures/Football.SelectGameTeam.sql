--select from the table gameteam all parameters are optional 


CREATE OR ALTER PROCEDURE Football.GetGameTeam
    @GameTeamId INT = NULL,
    @TeamId INT = NULL,
    @GameId INT = NULL,
    @TeamTypeId INT = NULL,
    @TopOfPossessionSec INT = NULL,
    @Score INT = NULL
AS
BEGIN
    SELECT *
    FROM Football.GameTeam
    WHERE (@GameTeamId IS NULL OR GameTeamId = @GameTeamId)
      AND (@TeamId IS NULL OR TeamId = @TeamId)
      AND (@GameId IS NULL OR GameId = @GameId)
      AND (@TeamTypeId IS NULL OR TeamTypeId = @TeamTypeId)
      AND (@TopOfPossessionSec IS NULL OR TopOfPossessionSec = @TopOfPossessionSec)
      AND (@Score IS NULL OR Score = @Score);
END;
GO

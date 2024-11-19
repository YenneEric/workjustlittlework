
--inserts a GameTeam row based on, gameid, teamname, teamtypeid, TOP, and score, then it outputs the GameTeamId

CREATE OR ALTER PROCEDURE Football.CreateGameTeam
    @GameId INT,
    @TeamName NVARCHAR(255),
    @TeamTypeId INT,
    @TopOfPossessionSec INT,
    @Score INT,
    @GameTeamId INT OUTPUT 
AS
BEGIN
    DECLARE @TeamId INT;

    SELECT @TeamId = TeamId
    FROM Football.Team
    WHERE TeamName = @TeamName;

   

    INSERT INTO Football.GameTeam (GameId, TeamId, TeamTypeId, TopOfPossessionSec, Score)
    VALUES (@GameId, @TeamId, @TeamTypeId, @TopOfPossessionSec, @Score);

   
    SET @GameTeamId = SCOPE_IDENTITY();

  
END;
GO


--inserts a row in the team player table and outputs the teamplayer id

CREATE OR ALTER PROCEDURE Football.CreateTeamPlayer
    @JerseyNumber INT,
    @Year NVARCHAR(50),
    @TeamName NVARCHAR(255),
    @PlayerId INT,
    @TeamPlayerId INT OUTPUT
AS
BEGIN
    DECLARE @SeasonId INT, @TeamId INT;

    SELECT @SeasonId = SeasonId
    FROM Football.Season
    WHERE Year = @Year;

    

    SELECT @TeamId = TeamId
    FROM Football.Team
    WHERE TeamName = @TeamName;

    
    INSERT INTO Football.TeamPlayer (PlayerId, SeasonId, TeamId, JerseyNumber)
    VALUES (@PlayerId, @SeasonId, @TeamId, @JerseyNumber);

    SET @TeamPlayerId = SCOPE_IDENTITY();
END;
GO

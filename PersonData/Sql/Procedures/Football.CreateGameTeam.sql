CREATE OR ALTER PROCEDURE Football.CreateGameTeam
    @GameId INT,
    @TeamName NVARCHAR(255),
    @TeamTypeId INT,
    @TopOfPossessionSec INT,
    @Score INT,
    @GameTeamId INT OUTPUT -- Output parameter to return the GameTeamId
AS
BEGIN
    DECLARE @TeamId INT;

    SELECT @TeamId = TeamId
    FROM Football.Team
    WHERE TeamName = @TeamName;

   

    INSERT INTO Football.GameTeam (GameId, TeamId, TeamTypeId, TopOfPossessionSec, Score)
    VALUES (@GameId, @TeamId, @TeamTypeId, @TopOfPossessionSec, @Score);

    -- Retrieve the generated GameTeamId
    SET @GameTeamId = SCOPE_IDENTITY();

    PRINT 'GameTeam created successfully.';
END;
GO

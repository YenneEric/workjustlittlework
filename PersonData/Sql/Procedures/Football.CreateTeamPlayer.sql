CREATE OR ALTER PROCEDURE Football.CreateTeamPlayer
    @JerseyNumber INT,
    @Year NVARCHAR(50),
    @TeamName NVARCHAR(255),
    @PlayerId INT,
    @TeamPlayerId INT OUTPUT
AS
BEGIN
    -- Declare variables for SeasonId and TeamId
    DECLARE @SeasonId INT, @TeamId INT;

    -- Get SeasonId based on Year
    SELECT @SeasonId = SeasonId
    FROM Football.Season
    WHERE Year = @Year;

    

    -- Get TeamId based on TeamName
    SELECT @TeamId = TeamId
    FROM Football.Team
    WHERE TeamName = @TeamName;

    
    -- Insert the new TeamPlayer record
    INSERT INTO Football.TeamPlayer (PlayerId, SeasonId, TeamId, JerseyNumber)
    VALUES (@PlayerId, @SeasonId, @TeamId, @JerseyNumber);

    -- Retrieve the generated TeamPlayerId
    SET @TeamPlayerId = SCOPE_IDENTITY();
END;
GO

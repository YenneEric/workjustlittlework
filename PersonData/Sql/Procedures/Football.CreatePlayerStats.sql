CREATE OR ALTER PROCEDURE Football.CreatePlayerStats
    @PlayerId INT,
    @SeasonYear NVARCHAR(50),
    @TeamName NVARCHAR(255),
    @GameId INT,
    @RushingYards INT = 0,
    @ReceivingYards INT = 0,
    @ThrowingYards INT = 0,
    @Tackles INT = 0,
    @Sacks INT = 0,
    @Turnovers INT = 0,
    @InterceptionsCaught INT = 0,
    @FieldGoalsMade INT = 0,
    @Touchdowns INT = 0,
    @Punts INT = 0
AS
BEGIN
    DECLARE @TeamPlayerId INT, @TeamId INT, @SeasonId INT;

    -- Get SeasonId based on the season year
    SELECT @SeasonId = SeasonId
    FROM Football.Season
    WHERE Year = @SeasonYear;

    
    -- Get TeamId based on the team name
    SELECT @TeamId = TeamId
    FROM Football.Team
    WHERE TeamName = @TeamName;

   

    -- Get TeamPlayerId based on PlayerId, TeamId, and SeasonId
    SELECT @TeamPlayerId = TeamPlayerId
    FROM Football.TeamPlayer
    WHERE PlayerId = @PlayerId AND TeamId = @TeamId AND SeasonId = @SeasonId;

   

    -- Insert the new PlayerStats record
    INSERT INTO Football.PlayerStats (
        TeamPlayerId,
        TeamId,
        GameId,
        RushingYards,
        ReceivingYards,
        ThrowingYards,
        Tackles,
        Sacks,
        Turnovers,
        InterceptionsCaught,
        FieldGoalsMade,
        Touchdowns,
        Punts
    )
    VALUES (
        @TeamPlayerId,
        @TeamId,
        @GameId,
        @RushingYards,
        @ReceivingYards,
        @ThrowingYards,
        @Tackles,
        @Sacks,
        @Turnovers,
        @InterceptionsCaught,
        @FieldGoalsMade,
        @Touchdowns,
        @Punts 
    );
END;
GO

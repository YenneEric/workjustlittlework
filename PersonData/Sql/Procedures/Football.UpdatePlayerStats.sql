CREATE OR ALTER PROCEDURE Football.UpdatePlayerStats
    @PlayerStatsId INT,               -- The ID of the PlayerStats to update
    @RushingYards INT = NULL,         -- Optional: New rushing yards
    @ReceivingYards INT = NULL,       -- Optional: New receiving yards
    @ThrowingYards INT = NULL,        -- Optional: New throwing yards
    @Tackles INT = NULL,              -- Optional: New tackles
    @Sacks INT = NULL,                -- Optional: New sacks
    @Turnovers INT = NULL,            -- Optional: New turnovers
    @InterceptionsCaught INT = NULL, -- Optional: New interceptions caught
    @Touchdowns INT = NULL,           -- Optional: New touchdowns
    @Punts INT = NULL,                -- Optional: New punts
    @FieldGoalsMade INT = NULL        -- Optional: New field goals made
AS
BEGIN
    UPDATE Football.PlayerStats
    SET 
        RushingYards = COALESCE(@RushingYards, RushingYards),
        ReceivingYards = COALESCE(@ReceivingYards, ReceivingYards),
        ThrowingYards = COALESCE(@ThrowingYards, ThrowingYards),
        Tackles = COALESCE(@Tackles, Tackles),
        Sacks = COALESCE(@Sacks, Sacks),
        Turnovers = COALESCE(@Turnovers, Turnovers),
        InterceptionsCaught = COALESCE(@InterceptionsCaught, InterceptionsCaught),
        Touchdowns = COALESCE(@Touchdowns, Touchdowns),
        Punts = COALESCE(@Punts, Punts),
        FieldGoalsMade = COALESCE(@FieldGoalsMade, FieldGoalsMade)
    WHERE 
        PlayerStatsId = @PlayerStatsId;

    
END;
GO

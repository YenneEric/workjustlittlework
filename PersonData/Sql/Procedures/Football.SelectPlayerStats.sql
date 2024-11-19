CREATE OR ALTER PROCEDURE Football.GetPlayerStats
    @PlayerStatsId INT = NULL,
    @TeamPlayerId INT = NULL,
    @GameId INT = NULL,
    @TeamId INT = NULL,
    @RushingYards INT = NULL,
    @ReceivingYards INT = NULL,
    @ThrowingYards INT = NULL,
    @Tackles INT = NULL,
    @Sacks INT = NULL,
    @Turnovers INT = NULL,
    @InterceptionsCaught INT = NULL,
    @Touchdowns INT = NULL,
    @FieldGoalsMade INT = NULL,
    @Punts INT = NULL
AS
BEGIN
    SELECT *
    FROM Football.PlayerStats
    WHERE (@PlayerStatsId IS NULL OR PlayerStatsId = @PlayerStatsId)
      AND (@TeamPlayerId IS NULL OR TeamPlayerId = @TeamPlayerId)
      AND (@GameId IS NULL OR GameId = @GameId)
      AND (@TeamId IS NULL OR TeamId = @TeamId)
      AND (@RushingYards IS NULL OR RushingYards = @RushingYards)
      AND (@ReceivingYards IS NULL OR ReceivingYards = @ReceivingYards)
      AND (@ThrowingYards IS NULL OR ThrowingYards = @ThrowingYards)
      AND (@Tackles IS NULL OR Tackles = @Tackles)
      AND (@Sacks IS NULL OR Sacks = @Sacks)
      AND (@Turnovers IS NULL OR Turnovers = @Turnovers)
      AND (@InterceptionsCaught IS NULL OR InterceptionsCaught = @InterceptionsCaught)
      AND (@Touchdowns IS NULL OR Touchdowns = @Touchdowns)
      AND (@FieldGoalsMade IS NULL OR FieldGoalsMade = @FieldGoalsMade)
      AND (@Punts IS NULL OR Punts = @Punts);
END;
GO

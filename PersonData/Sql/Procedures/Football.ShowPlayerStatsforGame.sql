CREATE OR ALTER PROCEDURE Football.GetPlayerStatsByGameAndTeam
    @GameId INT,
    @TeamName NVARCHAR(255),
    @PlayerId INT = NULL 
AS
BEGIN
    SELECT 
        p.PlayerName,
        p.Position,
        ps.RushingYards,
        ps.ReceivingYards,
        ps.ThrowingYards,
        ps.Tackles,
        ps.Sacks,
        ps.Turnovers,
        ps.InterceptionsCaught,
        ps.Touchdowns,
        ps.Punts,
        ps.FieldGoalsMade
    FROM Football.PlayerStats ps
    INNER JOIN Football.TeamPlayer tp ON ps.TeamPlayerId = tp.TeamPlayerId
    INNER JOIN Football.Player p ON tp.PlayerId = p.PlayerId
    INNER JOIN Football.Team t ON tp.TeamId = t.TeamId
    INNER JOIN Football.GameTeam gt ON ps.GameId = gt.GameId AND gt.TeamId = t.TeamId
    WHERE gt.GameId = @GameId
      AND t.TeamName = @TeamName
      AND (@PlayerId IS NULL OR p.PlayerId = @PlayerId);
END;
GO

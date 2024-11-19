-- This is one of the aggregating querys that give the rank and the team based on touchdowns. Given a year and a position 


CREATE OR ALTER PROCEDURE Football.FetchTouchdownsRank
    @Year INT,
    @Position NVARCHAR(50)
AS
BEGIN
    SELECT 
        p.PlayerId,
        p.PlayerName,
        p.Position,
        t.TeamName,
        SUM(ps.Touchdowns) AS TotalTouchdowns,
        RANK() OVER (ORDER BY SUM(ps.Touchdowns) DESC) AS PositionRank
    FROM 
        PlayerStats ps
    INNER JOIN 
        TeamPlayer tp ON ps.TeamPlayerId = tp.TeamPlayerId
    INNER JOIN 
        Player p ON tp.PlayerId = p.PlayerId
    INNER JOIN 
        Team t ON tp.TeamId = t.TeamId
    INNER JOIN 
        Season s ON tp.SeasonId = s.SeasonId
    WHERE 
        s.Year = @Year
        AND p.Position = @Position
    GROUP BY 
        p.PlayerId, p.PlayerName, p.Position, t.TeamName
    ORDER BY 
        PositionRank;
END;
GO

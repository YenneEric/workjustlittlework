CREATE OR ALTER PROCEDURE Football.FetchTopScoringTeams
    @Year INT
AS
BEGIN
    SELECT 
        t.TeamName,
        SUM(CAST(gt.Score AS INT)) AS TotalPoints,  -- Explicit casting to INT
        COUNT(gt.GameId) AS GamesPlayed,
        AVG(CAST(gt.Score AS DECIMAL(10, 2))) AS AveragePoints,  -- Explicit casting for AVG
        RANK() OVER (ORDER BY SUM(CAST(gt.Score AS INT)) DESC) AS TeamRank
    FROM 
        GameTeam gt
    JOIN 
        Game g ON gt.GameId = g.GameId
    JOIN 
        Team t ON gt.TeamId = t.TeamId
    JOIN 
        TeamPlayer tp ON tp.TeamId = t.TeamId
    JOIN 
        Season s ON tp.SeasonId = s.SeasonId
    WHERE 
        s.Year = @Year
    GROUP BY 
        t.TeamId, t.TeamName, s.Year
    ORDER BY 
        TotalPoints DESC;
END;
GO
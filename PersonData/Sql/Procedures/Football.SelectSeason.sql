CREATE OR ALTER PROCEDURE Football.GetSeason
    @SeasonId INT = NULL,
    @Year INT = NULL
AS
BEGIN
    SELECT *
    FROM Football.Season
    WHERE (@SeasonId IS NULL OR SeasonId = @SeasonId)
      AND (@Year IS NULL OR [Year] = @Year);
END;
GO

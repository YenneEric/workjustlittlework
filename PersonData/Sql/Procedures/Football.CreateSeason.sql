CREATE OR ALTER PROCEDURE Football.CreateSeason
    @Year INT -- Year for the season
AS
BEGIN
    -- Insert the new season if it doesn't already exist
    INSERT INTO Football.Season ([Year])
    SELECT @Year
    WHERE NOT EXISTS (
        SELECT 1
        FROM Football.Season
        WHERE [Year] = @Year
    );
END;
GO

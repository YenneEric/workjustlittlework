
--inserts row in the seaon table 

CREATE OR ALTER PROCEDURE Football.CreateSeason
    @Year INT 
AS
BEGIN
    
    INSERT INTO Football.Season ([Year])
    SELECT @Year
    WHERE NOT EXISTS (
        SELECT 1
        FROM Football.Season
        WHERE [Year] = @Year
    );
END;
GO

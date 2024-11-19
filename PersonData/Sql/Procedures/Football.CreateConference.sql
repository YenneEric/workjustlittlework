
--inserts a Conference based on the conference name 

CREATE OR ALTER PROCEDURE Football.CreateConference
    @ConfName NVARCHAR(255) 
AS
BEGIN
    
    INSERT INTO Football.Conference (ConfName)
    SELECT @ConfName
    WHERE NOT EXISTS (
        SELECT 1
        FROM Football.Conference
        WHERE ConfName = @ConfName
    );
END;
GO

CREATE OR ALTER PROCEDURE Football.CreateConference
    @ConfName NVARCHAR(255) -- Conference Name
AS
BEGIN
    -- Insert the new conference if it doesn't already exist
    INSERT INTO Football.Conference (ConfName)
    SELECT @ConfName
    WHERE NOT EXISTS (
        SELECT 1
        FROM Football.Conference
        WHERE ConfName = @ConfName
    );
END;
GO

CREATE OR ALTER PROCEDURE Football.CreatePlayer
    @PlayerName NVARCHAR(255),
    @Position NVARCHAR(50),
    @PlayerId INT OUTPUT
AS
BEGIN
    -- Insert the player into the table
    INSERT INTO Football.Player (PlayerName, Position)
    VALUES (@PlayerName, @Position);

    -- Retrieve the generated PlayerId
    SET @PlayerId = SCOPE_IDENTITY();
END;
GO

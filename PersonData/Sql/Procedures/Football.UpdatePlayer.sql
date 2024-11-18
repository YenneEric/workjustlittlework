CREATE OR ALTER PROCEDURE Football.UpdatePlayer
    @PlayerId INT,           
    @PlayerName NVARCHAR(255) = NULL,
    @Position NVARCHAR(50) = NULL    
AS
BEGIN
    
    UPDATE Football.Player
    SET
        PlayerName = COALESCE(@PlayerName, PlayerName), -- Update if provided, otherwise keep existing value
        Position = COALESCE(@Position, Position)       -- Update if provided, otherwise keep existing value
    WHERE
        PlayerId = @PlayerId;

   
END;
GO

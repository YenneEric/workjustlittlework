
--update on the table player where the  id is required and rest are optional, 
--only updates the column if a new value is provided

CREATE OR ALTER PROCEDURE Football.UpdatePlayer
    @PlayerId INT,           
    @PlayerName NVARCHAR(255) = NULL,
    @Position NVARCHAR(50) = NULL    
AS
BEGIN
    
    UPDATE Football.Player
    SET
        PlayerName = COALESCE(@PlayerName, PlayerName), 
        Position = COALESCE(@Position, Position)       
    WHERE
        PlayerId = @PlayerId;

   
END;
GO


--inserts row in Player table based on player name, poistion, and then outputs the playerid

CREATE OR ALTER PROCEDURE Football.CreatePlayer
    @PlayerName NVARCHAR(255),
    @Position NVARCHAR(50),
    @PlayerId INT OUTPUT
AS
BEGIN
   
    INSERT INTO Football.Player (PlayerName, Position)
    VALUES (@PlayerName, @Position);

   
    SET @PlayerId = SCOPE_IDENTITY();
END;
GO

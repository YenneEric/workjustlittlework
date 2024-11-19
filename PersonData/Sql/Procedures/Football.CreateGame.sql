
--inserts A Game row based on Date, Location and outputs the Gameid

CREATE OR ALTER PROCEDURE Football.CreateGame
    @Date DATE,
    @Location NVARCHAR(255),
    @Canceled INT = 0, -- 0 = Not Canceled, 1 = Canceled
    @GameId INT OUTPUT
AS
BEGIN
    
    INSERT INTO Football.Game ([Date], [Location], Canceled)
    VALUES (@Date, @Location, @Canceled);

    
    SET @GameId = SCOPE_IDENTITY();

END;
GO

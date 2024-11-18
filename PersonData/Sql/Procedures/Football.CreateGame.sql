CREATE OR ALTER PROCEDURE Football.CreateGame
    @Date DATE,
    @Location NVARCHAR(255),
    @Canceled INT = 0, -- 0 = Not Canceled, 1 = Canceled
    @GameId INT OUTPUT
AS
BEGIN
    -- Insert the new game into the Football.Game table
    INSERT INTO Football.Game ([Date], [Location], Canceled)
    VALUES (@Date, @Location, @Canceled);

    -- Retrieve the newly created GameId
    SET @GameId = SCOPE_IDENTITY();

END;
GO

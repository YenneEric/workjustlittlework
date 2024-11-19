CREATE OR ALTER PROCEDURE Football.UpdateGame
    @GameId INT,         -- The ID of the game to update
    @Date DATE = NULL,   -- The new date of the game (optional)
    @Location NVARCHAR(255) = NULL, -- The new location of the game (optional)
    @Canceled INT = NULL -- The canceled status of the game (optional)
AS
BEGIN
   
    -- Update the game
    UPDATE Football.Game
    SET
        [Date] = COALESCE(@Date, [Date]),  -- Update only if a new value is provided
        [Location] = COALESCE(@Location, [Location]), -- Update only if a new value is provided
        [Canceled] = COALESCE(@Canceled, [Canceled]) -- Update only if a new value is provided
    WHERE
        GameId = @GameId;

END;
GO

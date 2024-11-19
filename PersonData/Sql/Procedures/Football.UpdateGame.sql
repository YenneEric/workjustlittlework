
--update on the table game where game id is required and rest are optional, only updates the column if a new value is provided

CREATE OR ALTER PROCEDURE Football.UpdateGame
    @GameId INT,         
    @Date DATE = NULL,   
    @Location NVARCHAR(255) = NULL, 
    @Canceled INT = NULL 
AS
BEGIN
   
    
    UPDATE Football.Game
    SET
        [Date] = COALESCE(@Date, [Date]),  
        [Location] = COALESCE(@Location, [Location]), 
        [Canceled] = COALESCE(@Canceled, [Canceled]) 
    WHERE
        GameId = @GameId;

END;
GO

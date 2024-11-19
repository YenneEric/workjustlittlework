CREATE OR ALTER PROCEDURE Football.GetGame
    @GameId INT = NULL,
    @Location NVARCHAR(255) = NULL,
    @Canceled INT = NULL
AS
BEGIN
    SELECT *
    FROM Football.Game
    WHERE (@GameId IS NULL OR GameId = @GameId)
      AND (@Location IS NULL OR Location = @Location)
      AND (@Canceled IS NULL OR Canceled = @Canceled);
END;
GO

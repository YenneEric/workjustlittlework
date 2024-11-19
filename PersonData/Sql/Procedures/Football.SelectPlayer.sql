CREATE OR ALTER PROCEDURE Football.GetPlayer
    @PlayerId INT = NULL, -- Optional parameter for PlayerId
    @Position NVARCHAR(50) = NULL -- Optional parameter for Position
AS
BEGIN
    SELECT *
    FROM Football.Player
    WHERE (@PlayerId IS NULL OR PlayerId = @PlayerId) -- Filter by PlayerId if provided
      AND (@Position IS NULL OR Position = @Position); -- Filter by Position if provided
END;
GO

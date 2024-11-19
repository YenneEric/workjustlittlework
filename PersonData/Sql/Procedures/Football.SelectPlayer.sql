
--select from the table player all parameters are optional 


CREATE OR ALTER PROCEDURE Football.GetPlayer
    @PlayerId INT = NULL, 
    @Position NVARCHAR(50) = NULL 
AS
BEGIN
    SELECT *
    FROM Football.Player
    WHERE (@PlayerId IS NULL OR PlayerId = @PlayerId)
      AND (@Position IS NULL OR Position = @Position); 
END;
GO

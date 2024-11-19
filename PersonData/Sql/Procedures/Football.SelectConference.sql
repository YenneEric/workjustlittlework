--select from the table conference all parameters are optional 

CREATE OR ALTER PROCEDURE Football.GetConference
    @ConfId INT = NULL,
    @ConfName NVARCHAR(255) = NULL
AS
BEGIN
    SELECT *
    FROM Football.Conference
    WHERE (@ConfId IS NULL OR ConfId = @ConfId)
      AND (@ConfName IS NULL OR ConfName = @ConfName);
END;
GO

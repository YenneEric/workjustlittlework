CREATE OR ALTER PROCEDURE Football.GetTeam
    @TeamId INT = NULL,
    @TeamName NVARCHAR(255) = NULL,
    @Location NVARCHAR(255) = NULL,
    @Mascot NVARCHAR(255) = NULL,
    @ConfId INT = NULL
AS
BEGIN
    SELECT *
    FROM Football.Team
    WHERE (@TeamId IS NULL OR TeamId = @TeamId)
      AND (@TeamName IS NULL OR TeamName = @TeamName)
      AND (@Location IS NULL OR Location = @Location)
      AND (@Mascot IS NULL OR Mascot = @Mascot)
      AND (@ConfId IS NULL OR ConfId = @ConfId);
END;
GO

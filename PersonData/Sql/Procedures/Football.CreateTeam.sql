
--insert row in the team column and ouput the teamid

CREATE OR ALTER PROCEDURE Football.CreateTeam
    @TeamName NVARCHAR(255),
    @Location NVARCHAR(255),
    @Mascot NVARCHAR(255),
    @ConfName NVARCHAR(255),
    @TeamId INT OUTPUT
AS
BEGIN
    DECLARE @ConfId INT;

    
    SELECT @ConfId = ConfId
    FROM Football.Conference
    WHERE ConfName = @ConfName;

   
    
    INSERT INTO Football.Team (TeamName, Location, Mascot, ConfId)
    VALUES (@TeamName, @Location, @Mascot, @ConfId);

    
    SET @TeamId = SCOPE_IDENTITY();

END;
GO

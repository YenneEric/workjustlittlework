CREATE OR ALTER PROCEDURE Football.CreateTeam
    @TeamName NVARCHAR(255),
    @Location NVARCHAR(255),
    @Mascot NVARCHAR(255),
    @ConfName NVARCHAR(255),
    @TeamId INT OUTPUT -- Output parameter to return the TeamId
AS
BEGIN
    DECLARE @ConfId INT;

    -- Retrieve the ConfId based on the ConfName
    SELECT @ConfId = ConfId
    FROM Football.Conference
    WHERE ConfName = @ConfName;

   
    -- Insert the team into the Football.Team table
    INSERT INTO Football.Team (TeamName, Location, Mascot, ConfId)
    VALUES (@TeamName, @Location, @Mascot, @ConfId);

    -- Retrieve the generated TeamId
    SET @TeamId = SCOPE_IDENTITY();

END;
GO

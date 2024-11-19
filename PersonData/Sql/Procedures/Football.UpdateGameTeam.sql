CREATE OR ALTER PROCEDURE Football.UpdateGameTeam
    @GameTeamId INT,
    @TeamTypeId INT,
    @TopOfPossessionSec INT = NULL,
    @Score INT = NULL
AS
BEGIN
    -- Update the GameTeam record with the given GameTeamId
    UPDATE Football.GameTeam
    SET
        TeamTypeId = @TeamTypeId,
        TopOfPossessionSec = @TopOfPossessionSec,
        Score = @Score
    WHERE
        GameTeamId = @GameTeamId;

    PRINT 'GameTeam updated successfully.';
END;
GO

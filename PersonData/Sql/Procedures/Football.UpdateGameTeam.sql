
--update on the table gameteam where the two ids is required and rest are optional, 
--only updates the column if a new value is provided


CREATE OR ALTER PROCEDURE Football.UpdateGameTeam
    @GameTeamId INT,
    @TeamTypeId INT,
    @TopOfPossessionSec INT = NULL,
    @Score INT = NULL
AS
BEGIN
    
    UPDATE Football.GameTeam
    SET
        TeamTypeId = @TeamTypeId,
        TopOfPossessionSec = @TopOfPossessionSec,
        Score = @Score
    WHERE
        GameTeamId = @GameTeamId;

   
END;
GO

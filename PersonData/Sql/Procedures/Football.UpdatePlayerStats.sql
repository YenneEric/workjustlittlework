
--update on the table playerstats where the id is required and rest are optional, 
--only updates the column if a new value is provided

CREATE OR ALTER PROCEDURE Football.UpdatePlayerStats
    @PlayerStatsId INT,               
    @RushingYards INT = NULL,         
    @ReceivingYards INT = NULL,       
    @ThrowingYards INT = NULL,       
    @Tackles INT = NULL,             
    @Sacks INT = NULL,                
    @Turnovers INT = NULL,            
    @InterceptionsCaught INT = NULL, 
    @Touchdowns INT = NULL,          
    @Punts INT = NULL,                
    @FieldGoalsMade INT = NULL        
AS
BEGIN
    UPDATE Football.PlayerStats
    SET 
        RushingYards = COALESCE(@RushingYards, RushingYards),
        ReceivingYards = COALESCE(@ReceivingYards, ReceivingYards),
        ThrowingYards = COALESCE(@ThrowingYards, ThrowingYards),
        Tackles = COALESCE(@Tackles, Tackles),
        Sacks = COALESCE(@Sacks, Sacks),
        Turnovers = COALESCE(@Turnovers, Turnovers),
        InterceptionsCaught = COALESCE(@InterceptionsCaught, InterceptionsCaught),
        Touchdowns = COALESCE(@Touchdowns, Touchdowns),
        Punts = COALESCE(@Punts, Punts),
        FieldGoalsMade = COALESCE(@FieldGoalsMade, FieldGoalsMade)
    WHERE 
        PlayerStatsId = @PlayerStatsId;

    
END;
GO

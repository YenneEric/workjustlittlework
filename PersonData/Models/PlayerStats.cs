using System;

namespace PersonData.Models
{
    public class PlayerStats
    {
        public int PlayerStatsId { get; }
        public int TeamPlayerId { get; }
        public int GameId { get; }
        public int TeamId { get; }
        public int RushingYards { get; }
        public int ReceivingYards { get; }
        public int ThrowingYards { get; }
        public int Tackles { get; }
        public int Sacks { get; }
        public int Turnovers { get; }
        public int InterceptionsCaught { get; }
        public int Touchdowns { get; }
        public int FieldGoalsMade { get; }

        public int Punts { get; }

        public PlayerStats(int playerStatsId, int teamPlayerId, int gameId, int teamId, int rushingYards, int receivingYards, int throwingYards, int tackles, int sacks, int turnovers, int interceptionsCaught, int touchdowns, int fieldGoalsMade, int punts)
        {
            PlayerStatsId = playerStatsId;
            TeamPlayerId = teamPlayerId;
            GameId = gameId;
            TeamId = teamId;
            RushingYards = rushingYards;
            ReceivingYards = receivingYards;
            ThrowingYards = throwingYards;
            Tackles = tackles;
            Sacks = sacks;
            Turnovers = turnovers;
            InterceptionsCaught = interceptionsCaught;
            Touchdowns = touchdowns;
            FieldGoalsMade = fieldGoalsMade;
            Punts = punts;
        }
    }
}

using System;

namespace PersonData.Models
{
    public class GameTeam
    {
        public int GameTeamId { get; }
        public int TeamId { get; }
        public int GameId { get; }
        public int TeamTypeId { get; }
        public int? TopOfPossessionSec { get; }
        public int? Score { get; }

        public GameTeam(int gameTeamId, int teamId, int gameId, int teamTypeId, int? topOfPossessionSec, int? score)
        {
            GameTeamId = gameTeamId;
            TeamId = teamId;
            GameId = gameId;
            TeamTypeId = teamTypeId;
            TopOfPossessionSec = topOfPossessionSec;
            Score = score;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonData
{
    public interface IUpdate
    {

        void UpdatePlayer(int playerId, string playerName = null, string position = null);

        void UpdateTeam(int teamId, string teamName = null, string location = null, string mascot = null, int? confId = null);


        void UpdatePlayerStats(
            int playerStatsId,
            int? rushingYards = null,
           int? receivingYards = null,
            int? throwingYards = null,
           int? tackles = null,
            int? sacks = null,
           int? turnovers = null,
           int? interceptionsCaught = null,
           int? touchdowns = null,
             int? punts = null,
            int? fieldGoalsMade = null);



        void UpdateGame(int gameId, DateTime? date = null, string location = null, int? canceled = null);

        void UpdateGameTeam(int gameTeamId, int teamTypeId, int? topOfPossessionSec = null, int? score = null);


    }
}

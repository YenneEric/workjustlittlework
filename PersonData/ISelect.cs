using PersonData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonData
{
    public interface ISelect
    {
        List<Player> GetPlayers(int? playerId = null, string position = null);


        List<TeamPlayer> GetTeamPlayers(int? playerId = null, int? seasonId = null, int? teamId = null, int? jerseyNumber = null);

        List<PlayerStats> GetPlayerStats(
            int? playerStatsId = null,
            int? teamPlayerId = null,
            int? gameId = null,
            int? teamId = null,
            int? rushingYards = null,
            int? receivingYards = null,
            int? throwingYards = null,
            int? tackles = null,
            int? sacks = null,
            int? turnovers = null,
            int? interceptionsCaught = null,
            int? touchdowns = null,
            int? fieldGoalsMade = null,
            int? punts = null);

        List<GameTeam> GetGameTeams(
          int? gameTeamId = null,
          int? teamId = null,
          int? gameId = null,
          int? teamTypeId = null,
          int? topOfPossessionSec = null,
          int? score = null);


        List<TeamType> GetTeamTypes(int? teamTypeId = null, string name = null);

        List<Game> GetGames(int? gameId = null, string location = null, bool? canceled = null);


        List<Team> GetTeams(int? teamId = null, string teamName = null, string location = null, string mascot = null, int? confId = null);

        List<Conference> GetConferences(int? confId = null, string confName = null);


        List<Season> GetSeasons(int? seasonId = null, int? year = null);

    }
}

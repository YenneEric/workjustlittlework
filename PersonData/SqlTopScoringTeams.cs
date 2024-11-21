using PersonData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonData
{
    public class SqlTopScoringTeam : IStatRepository
    {
        private readonly string connectionString;

        public SqlTopScoringTeam(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IReadOnlyList<PlayerTouchdownRank> FetchTouchdownPlayer(string pos, int year)
        {
            if (string.IsNullOrWhiteSpace(pos))
                throw new ArgumentException("Position cannot be null or empty.", nameof(pos));

            if (year <= 0)
                throw new ArgumentException("Year must be a positive integer.", nameof(year));

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Football.FetchTouchdownsRank", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("Year", year);
                    command.Parameters.AddWithValue("Position", pos);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var stats = TranslatePlayerTouchdownStats(reader);

                        if (stats.Count == 0)
                            throw new RecordNotFoundException($"No players found for position {pos} in year {year}.");

                        return stats;
                    }
                }
            }
        }

        public IReadOnlyList<GameSchedule> FetchGameSchedule(string teamName, int year)
        {
            if (string.IsNullOrWhiteSpace(teamName))
                throw new ArgumentException("Team name cannot be null or empty.", nameof(teamName));

            if (year <= 0)
                throw new ArgumentException("Year must be a positive integer.", nameof(year));

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Football.GetTeamSchedule", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@TeamName", teamName);
                    command.Parameters.AddWithValue("@Year", year);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var schedule = TranslateGameSchedule(reader);

                        if (schedule.Count == 0)
                            throw new RecordNotFoundException($"No schedule found for team {teamName} in year {year}.");

                        return schedule;
                    }
                }
            }
        }

        // Helper method to translate player touchdown stats from SQL
        private List<PlayerTouchdownRank> TranslatePlayerTouchdownStats(SqlDataReader reader)
        {
            var stats = new List<PlayerTouchdownRank>();

            var playerIdOrdinal = reader.GetOrdinal("PlayerId");
            var playerNameOrdinal = reader.GetOrdinal("PlayerName");
            var positionOrdinal = reader.GetOrdinal("Position");
            var teamNameOrdinal = reader.GetOrdinal("TeamName");
            var totalTouchdownsOrdinal = reader.GetOrdinal("TotalTouchdowns");
            var positionRankOrdinal = reader.GetOrdinal("PositionRank");

            while (reader.Read())
            {
                var player = new Player(
                    reader.GetInt32(playerIdOrdinal),
                    reader.GetString(playerNameOrdinal),
                    reader.GetString(positionOrdinal)
                );

                var teamName = reader.GetString(teamNameOrdinal);
                var totalTouchdowns = reader.GetInt32(totalTouchdownsOrdinal);
                var positionRank = reader.GetInt64(positionRankOrdinal);

                stats.Add(new PlayerTouchdownRank(player, teamName, totalTouchdowns, positionRank));
            }

            return stats;
        }

        // Helper method to translate game schedule from SQL
        private List<GameSchedule> TranslateGameSchedule(SqlDataReader reader)
        {
            var schedule = new List<GameSchedule>();

            var gameDateOrdinal = reader.GetOrdinal("GameDate");
            var gameLocationOrdinal = reader.GetOrdinal("GameLocation");
            var teamNameOrdinal = reader.GetOrdinal("Team");
            var teamScoreOrdinal = reader.GetOrdinal("TeamScore");
            var teamTimeOfPossessionOrdinal = reader.GetOrdinal("TeamTimeOfPossession");
            var opponentNameOrdinal = reader.GetOrdinal("Opponent");
            var opponentScoreOrdinal = reader.GetOrdinal("OpponentScore");
            var opponentTimeOfPossessionOrdinal = reader.GetOrdinal("OpponentTimeOfPossession");
            var winnerOrdinal = reader.GetOrdinal("Winner");

            while (reader.Read())
            {
                schedule.Add(new GameSchedule
                {
                    GameDate = reader.GetDateTime(gameDateOrdinal).Date,
                    GameLocation = reader.GetString(gameLocationOrdinal),
                    TeamName = reader.GetString(teamNameOrdinal),
                    TeamScore = reader.IsDBNull(teamScoreOrdinal) ? (int?)null : reader.GetInt32(teamScoreOrdinal),
                    TeamTimeOfPossession = reader.IsDBNull(teamTimeOfPossessionOrdinal) ? (int?)null : reader.GetInt32(teamTimeOfPossessionOrdinal),
                    OpponentName = reader.GetString(opponentNameOrdinal),
                    OpponentScore = reader.IsDBNull(opponentScoreOrdinal) ? (int?)null : reader.GetInt32(opponentScoreOrdinal),
                    OpponentTimeOfPossession = reader.IsDBNull(opponentTimeOfPossessionOrdinal) ? (int?)null : reader.GetInt32(opponentTimeOfPossessionOrdinal),
                    Winner = reader.GetString(winnerOrdinal)
                });
            }

            return schedule;
        }


        public List<TopScoringTeamRank> FetchTopScoringTeams(int year)
        {
            if (year <= 0)
                throw new ArgumentException("Year must be a positive integer.", nameof(year));

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Football.FetchTopScoringTeams", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for year
                    command.Parameters.AddWithValue("Year", year);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var teams = TranslateTopScoringTeams(reader);

                        if (teams.Count == 0)
                            throw new RecordNotFoundException($"No top scoring teams found for year {year}.");

                        return teams;
                    }
                }
            }
        }

        private List<TopScoringTeamRank> TranslateTopScoringTeams(SqlDataReader reader)
        {
            var teams = new List<TopScoringTeamRank>();

            // Get column ordinals for efficiency
            var teamNameOrdinal = reader.GetOrdinal("TeamName");
            var totalPointsOrdinal = reader.GetOrdinal("TotalPoints");
            var gamesPlayedOrdinal = reader.GetOrdinal("GamesPlayed");
            var averagePointsOrdinal = reader.GetOrdinal("AveragePoints");
            var teamRankOrdinal = reader.GetOrdinal("TeamRank");

            while (reader.Read())
            {
                var teamName = reader.GetString(teamNameOrdinal);
                var totalPoints = reader.GetInt32(totalPointsOrdinal);
                var gamesPlayed = reader.GetInt32(gamesPlayedOrdinal);
                var averagePoints = reader.GetDecimal(averagePointsOrdinal);
                var teamRank = reader.GetInt64(teamRankOrdinal);

                teams.Add(new TopScoringTeamRank(teamName, totalPoints, gamesPlayed, averagePoints, teamRank));
            }

            return teams;
        }

        public IReadOnlyList<GamePlayerStats> FetchPlayerStatsByGameAndTeam(int gameId, string teamName, int? playerId = null)
        {
            throw new NotImplementedException();
        }

        public void EditPlayerStats(int gameId, string teamName, int playerId, int? rushingYards = null, int? receivingYards = null, int? throwingYards = null, int? tackles = null, int? sacks = null, int? turnovers = null, int? interceptionsCaught = null, int? touchdowns = null, int? punts = null, int? fieldGoalsMade = null)
        {
            throw new NotImplementedException();
        }
    }
}
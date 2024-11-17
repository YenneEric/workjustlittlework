using PersonData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace PersonData
{
    public class SqlTouchDownRepository : IStatRepository
    {
        private readonly string connectionString;

        public SqlTouchDownRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public IReadOnlyList<Player> FetchTouchdownPlayer(string pos, int year)
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
                        var players = TranslatePlayers(reader);

                        if (players.Count == 0)
                            throw new RecordNotFoundException($"No players found for position {pos} in year {year}.");

                        return players;
                    }
                }
            }
        }

        private List<Player> TranslatePlayers(SqlDataReader reader)
        {
            var players = new List<Player>();

            // Get column ordinals for efficiency
            var playerIdOrdinal = reader.GetOrdinal("PlayerId");
            var playerNameOrdinal = reader.GetOrdinal("PlayerName");
            var positionOrdinal = reader.GetOrdinal("Position");
            var teamNameOrdinal = reader.GetOrdinal("TeamName");
            var totalTouchdownsOrdinal = reader.GetOrdinal("TotalTouchdowns");
            var positionRankOrdinal = reader.GetOrdinal("PositionRank");

            while (reader.Read())
            {
                players.Add(new Player(
                    reader.IsDBNull(playerIdOrdinal) ? 0 : reader.GetInt32(playerIdOrdinal),
                    reader.IsDBNull(playerNameOrdinal) ? string.Empty : reader.GetString(playerNameOrdinal),
                    reader.IsDBNull(positionOrdinal) ? string.Empty : reader.GetString(positionOrdinal),
                    reader.IsDBNull(teamNameOrdinal) ? string.Empty : reader.GetString(teamNameOrdinal),
                    reader.IsDBNull(totalTouchdownsOrdinal) ? 0 : reader.GetInt32(totalTouchdownsOrdinal),
                    reader.IsDBNull(positionRankOrdinal) ? 0L : reader.GetInt64(positionRankOrdinal) // Correct for long
                ));
            }

            return players;
        }


    }
}

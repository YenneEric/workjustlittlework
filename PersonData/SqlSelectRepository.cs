using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonData.Models;

namespace PersonData
{
    public class SqlSelectRepository: ISelect
    {
        private readonly string connectionString;

        public SqlSelectRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public List<Player> GetPlayers(int? playerId = null, string position = null)
        {
            var players = new List<Player>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Football.GetPlayer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@PlayerId", (object)playerId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Position", (object)position ?? DBNull.Value);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            players.Add(new Player(
                                reader.GetInt32(reader.GetOrdinal("PlayerId")),
                                reader.GetString(reader.GetOrdinal("PlayerName")),
                                reader.GetString(reader.GetOrdinal("Position")),
                                "",0,0
                            ));
                        }
                    }
                }
            }

            return players;
        }


        public IReadOnlyList<TeamPlayer> GetTeamPlayers(
            int? teamPlayerId = null,
            int? playerId = null,
            int? seasonId = null,
            int? teamId = null)
        {
            var teamPlayers = new List<TeamPlayer>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("Football.GetTeamPlayer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add optional parameters
                    command.Parameters.AddWithValue("@TeamPlayerId", (object)teamPlayerId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PlayerId", (object)playerId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@SeasonId", (object)seasonId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TeamId", (object)teamId ?? DBNull.Value);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teamPlayers.Add(new TeamPlayer(
                                teamPlayerId: reader.GetInt32(reader.GetOrdinal("TeamPlayerId")),
                                playerId: reader.GetInt32(reader.GetOrdinal("PlayerId")),
                                seasonId: reader.GetInt32(reader.GetOrdinal("SeasonId")),
                                teamId: reader.GetInt32(reader.GetOrdinal("TeamId")),
                                jerseyNumber: reader.GetInt32(reader.GetOrdinal("JerseyNumber"))
                            ));
                        }
                    }
                }
            }

            return teamPlayers;
        }







    }



}


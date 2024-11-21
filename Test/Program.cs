using System;
using System.Collections.Generic;
using PersonData;
using PersonData.Models;

class Program
{
    static void Main()
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
        var statRepository = new SqlTouchDownRepository(connectionString);

        try
        {
            // Test: Fetch player stats for a given game ID and team name
            Console.WriteLine("Enter Game ID:");
            if (!int.TryParse(Console.ReadLine(), out var gameId))
            {
                Console.WriteLine("Invalid Game ID. Exiting...");
                return;
            }

            Console.WriteLine("Enter Team Name:");
            var teamName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(teamName))
            {
                Console.WriteLine("Team Name cannot be empty. Exiting...");
                return;
            }

            Console.WriteLine("Enter Player ID (optional, press Enter to skip):");
            var playerIdInput = Console.ReadLine();
            int? playerId = null;

            if (!string.IsNullOrWhiteSpace(playerIdInput))
            {
                if (int.TryParse(playerIdInput, out var parsedPlayerId))
                {
                    playerId = parsedPlayerId;
                }
                else
                {
                    Console.WriteLine("Invalid Player ID. Exiting...");
                    return;
                }
            }

            Console.WriteLine($"Fetching player stats for Game ID: {gameId}, Team Name: {teamName}, Player ID: {(playerId.HasValue ? playerId.Value.ToString() : "None")}...");
            var playerStats = statRepository.FetchPlayerStatsByGameAndTeam(gameId, teamName, playerId);

            if (playerStats.Count == 0)
            {
                Console.WriteLine("No player stats found for the given criteria.");
            }
            else
            {
                PrintPlayerStats(playerStats);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void PrintPlayerStats(IReadOnlyList<GamePlayerStats> playerStats)
    {
        Console.WriteLine("Player Stats:");
        foreach (var stats in playerStats)
        {
            Console.WriteLine($"Player ID: {stats.PlayerId}, Name: {stats.PlayerName}, Position: {stats.Position}");
            Console.WriteLine($"Rushing Yards: {stats.RushingYards}, Receiving Yards: {stats.ReceivingYards}, Throwing Yards: {stats.ThrowingYards}");
            Console.WriteLine($"Tackles: {stats.Tackles}, Sacks: {stats.Sacks}, Turnovers: {stats.Turnovers}");
            Console.WriteLine($"Interceptions: {stats.InterceptionsCaught}, Touchdowns: {stats.Touchdowns}");
            Console.WriteLine($"Punts: {stats.Punts}, Field Goals Made: {stats.FieldGoalsMade}");
            Console.WriteLine(new string('-', 40));
        }
    }
}

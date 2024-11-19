using PersonData;
using System;
using System.Data.SqlClient;

using System;
using System;

class Program
{
    static void Main()
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
        var playerRepo = new SqlSelectRepository(connectionString);

        try
        {
            Console.WriteLine("Fetching all players...");
            var allPlayers = playerRepo.GetPlayers();
            foreach (var player in allPlayers)
            {
                Console.WriteLine($"PlayerId: {player.PlayerId}, Name: {player.PlayerName}, Position: {player.Position}");
            }

            Console.WriteLine("\nFetching player with PlayerId = 1...");
            var playerById = playerRepo.GetPlayers(playerId: 1);
            foreach (var player in playerById)
            {
                Console.WriteLine($"PlayerId: {player.PlayerId}, Name: {player.PlayerName}, Position: {player.Position}");
            }

            Console.WriteLine("\nFetching players with Position = 'Quarterback'...");
            var quarterbacks = playerRepo.GetPlayers(position: "Quarterback");
            foreach (var player in quarterbacks)
            {
                Console.WriteLine($"PlayerId: {player.PlayerId}, Name: {player.PlayerName}, Position: {player.Position}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}


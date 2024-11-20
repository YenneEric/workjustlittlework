using PersonData;
using PersonData.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
        var scheduleRepository = new SqlTouchDownRepository(connectionString);

        try
        {
            // Test: Retrieve game schedule for a specific team and year
            Console.WriteLine("Game Schedule for 'Kansas State Wildcats' in 2023:");
            var gameSchedule = scheduleRepository.FetchGameSchedule("Kansas State Wildcats", 2019);
            PrintGameSchedule(gameSchedule);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void PrintGameSchedule(IReadOnlyList<GameSchedule> schedules)
    {
        if (schedules.Count == 0)
        {
            Console.WriteLine("No games found for the specified team and year.");
            return;
        }

        foreach (var game in schedules)
        {
            Console.WriteLine(game);
        }
    }
}

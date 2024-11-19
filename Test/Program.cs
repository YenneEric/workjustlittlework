using PersonData;
using System;
using System.Data.SqlClient;

using System;
using System;
using PersonData.Models;

class Program
{
    static void Main()
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
        var repository = new SqlSelectRepository(connectionString);

        try
        {
            // Test 1: Retrieve all seasons
            Console.WriteLine("All Seasons:");
            List<Season> allSeasons = repository.GetSeasons();
            PrintSeasons(allSeasons);

            // Test 2: Filter by SeasonId
            Console.WriteLine("\nSeasons with SeasonId = 1:");
            List<Season> filteredById = repository.GetSeasons(seasonId: 1);
            PrintSeasons(filteredById);

            // Test 3: Filter by Year
            Console.WriteLine("\nSeasons with Year = 2023:");
            List<Season> filteredByYear = repository.GetSeasons(year: 2023);
            PrintSeasons(filteredByYear);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void PrintSeasons(List<Season> seasons)
    {
        foreach (var season in seasons)
        {
            Console.WriteLine($"SeasonId: {season.SeasonId}, Year: {season.Year}");
        }
    }
}
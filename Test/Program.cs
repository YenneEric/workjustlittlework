using PersonData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

class Program
{
    static void Main()
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";

        try
{
            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Opening connection...");
                connection.Open();
                Console.WriteLine("Connection opened successfully.");

                using (var command = new SqlCommand("Football.FetchTouchdownsRank", connection))
                {
                    Console.WriteLine("Preparing command...");
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Year", 2019);
                    command.Parameters.AddWithValue("Position", "Quarterback");

                    Console.WriteLine("Executing command...");
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Reading results...");
                        while (reader.Read())
                        {
                            Console.WriteLine($"PlayerName: {reader["PlayerName"]}, TeamName: {reader["TeamName"]}, Touchdowns: {reader["TotalTouchdowns"]}");
                        }
                    }
                }
            }
        }
catch (Exception ex)
{
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}

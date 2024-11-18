using PersonData;

class Program
{
    static void Main()
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
        var repository = new SqlInsertRepository(connectionString);

        try
        {
            Console.WriteLine("Creating conference...");

            // Example conference name
            string confName = "testing";

            repository.CreateConference(confName);

            Console.WriteLine("Conference created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

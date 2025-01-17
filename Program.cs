using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Testar anslutning till databasen...");
        if (!DataManager.TestDatabaseConnection())
        {
            Console.WriteLine("Kunde inte ansluta till databasen. Avslutar programmet.");
            Environment.Exit(1);
        }

        Console.WriteLine("Välkommen till Scout Reports ND!");

        Console.WriteLine("Välj din roll:");
        Console.WriteLine("1. Scout");
        Console.WriteLine("2. Tränare");
        string roleChoice = Console.ReadLine();

        if (roleChoice == "1" && Login("Scouts"))
        {
            ScoutMenu.ShowScoutMenu();
        }
        else if (roleChoice == "2" && Login("Coaches"))
        {
            CoachMenu.ShowCoachMenu();
        }
        else
        {
            Console.WriteLine("Felaktigt val eller inloggningsuppgifter. Programmet avslutas.");
        }
    }

    static bool Login(string tableName)
    {
        Console.WriteLine($"Ange användarnamn för {tableName}:");
        string username = Console.ReadLine().Trim();

        Console.WriteLine("Ange lösenord:");
        string password = Console.ReadLine().Trim();

        using (var connection = DataManager.GetConnection())
        {
            string query = $"SELECT Password FROM {tableName} WHERE Username = @Username";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    string storedPassword = result.ToString();

                    if (storedPassword == password)
                    {
                        Console.WriteLine("Inloggning lyckades!");
                        return true;
                    }
                }
            }
        }

        Console.WriteLine("Felaktigt användarnamn eller lösenord.");
        return false;
    }
}
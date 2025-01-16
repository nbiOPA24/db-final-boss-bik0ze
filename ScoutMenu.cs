using System;
using Microsoft.Data.SqlClient;


public static class ScoutMenu
{
    public static void ListPlayersForScouts()
    {
        using (var connection = DataManager.GetConnection())
        {
            string query = "SELECT PlayerID, Name, Age, Position, Team, League FROM Players ORDER BY Name";
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("Lista över spelare (Scout):");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["PlayerID"]}, Namn: {reader["Name"]}, Ålder: {reader["Age"]}, Position: {reader["Position"]}, Lag: {reader["Team"]}, Liga: {reader["League"]}");
                    }
                }
            }
        }

        Console.WriteLine("\nVill du visa en rapport för en specifik spelare? (Ja/Nej):");
        string input = Console.ReadLine();
        if (input?.ToLower() == "ja")
        {
            Console.WriteLine("Ange spelarens ID:");
            int playerId = int.Parse(Console.ReadLine());
            DataManager.ShowPlayerReports(playerId);
        }
    }

    public static void ShowScoutMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nScout-meny:");
            Console.WriteLine("1. Lägg till ny spelare");
            Console.WriteLine("2. Skapa rapport för spelare");
            Console.WriteLine("3. Se lista över spelare");
            Console.WriteLine("4. Logga ut");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DataManager.AddPlayer();
                    break;
                case "2":
                    DataManager.CreateReport();
                    break;
                case "3":
                    ListPlayersForScouts();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Loggar ut...");
                    break;
                default:
                    Console.WriteLine("Felaktigt val, försök igen.");
                    break;
            }
        }
    }
}
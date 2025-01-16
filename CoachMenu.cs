using System;
using Microsoft.Data.SqlClient;


public static class CoachMenu
{
    public static void ListPlayersForCoaches()
    {
        using (var connection = DataManager.GetConnection())
        {
            string query = "SELECT PlayerID, Name, Age, Position, Team, League FROM Players ORDER BY Name";
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("Lista �ver spelare (Coach):");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["PlayerID"]}, Namn: {reader["Name"]}, �lder: {reader["Age"]}, Position: {reader["Position"]}, Lag: {reader["Team"]}, Liga: {reader["League"]}");
                    }
                }
            }
        }

        Console.WriteLine("\nVill du visa en rapport f�r en specifik spelare? (Ja/Nej):");
        string input = Console.ReadLine();
        if (input?.ToLower() == "ja")
        {
            Console.WriteLine("Ange spelarens ID:");
            int playerId = int.Parse(Console.ReadLine());
            DataManager.ShowPlayerReports(playerId);
        }
    }

    public static void ShowCoachMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nTr�nar-meny:");
            Console.WriteLine("1. Visa lista �ver spelare");
            Console.WriteLine("2. Logga ut");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListPlayersForCoaches();
                    break;
                case "2":
                    exit = true;
                    Console.WriteLine("Loggar ut...");
                    break;
                default:
                    Console.WriteLine("Felaktigt val, f�rs�k igen.");
                    break;
            }
        }
    }
}
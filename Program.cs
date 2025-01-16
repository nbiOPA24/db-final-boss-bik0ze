using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=gondolin667.org;Database=yhstudent72_ScoutingReportsND;User Id=yhstudent72;Password=tpgYYzkb7U$g;Encrypt=True;TrustServerCertificate=True;";


        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Anslutningen till databasen lyckades!");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
            Console.WriteLine("Felsökningsdetaljer:");
            foreach (SqlError error in ex.Errors)
            {
                Console.WriteLine($"- Felnummer: {error.Number}, Meddelande: {error.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Anslutningen misslyckades: {ex.Message}");
        }
    }
}


class Program
{
    // Lista för att lagra spelare
    static List<Player> players = new List<Player>();

    static void Main(string[] args)
    {
        Console.WriteLine("Välkommen till Scout Reports ND!");

        // Läs in spelardata från JSON vid programmets start
        LoadPlayersFromJson();

        // Inloggningsmeny
        Console.WriteLine("Välj din roll:");
        Console.WriteLine("1. Scout");
        Console.WriteLine("2. Tränare");
        string roleChoice = Console.ReadLine();

        // Hantera inloggning och navigera till respektive meny
        if (roleChoice == "1" && Login("Scout"))
        {
            ShowScoutMenu();
        }
        else if (roleChoice == "2" && Login("Tränare"))
        {
            ShowCoachMenu();
        }
        else
        {
            Console.WriteLine("Felaktigt val eller inloggningsuppgifter. Programmet avslutas.");
        }

        // Spara spelardata till JSON innan programmet avslutas
        SavePlayersToJson();
    }

    // Metod för att hantera inloggning
    static bool Login(string role)
    {
        // Bestäm rätt användarnamn och lösenord beroende på roll
        string correctUsername = role == "Scout" ? "Scout" : "Tränare";
        string correctPassword = role == "Scout" ? "scout123" : "coach123";

        Console.WriteLine($"Ange användarnamn för {role}:");
        string username = Console.ReadLine();

        Console.WriteLine("Ange lösenord:");
        string password = Console.ReadLine();

        if (username == correctUsername && password == correctPassword)
        {
            Console.WriteLine("Inloggning lyckades!");
            return true;
        }
        else
        {
            Console.WriteLine("Felaktigt användarnamn eller lösenord.");
            return false;
        }
    }
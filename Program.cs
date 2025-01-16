using System;
using System.Collections.Generic;

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
}
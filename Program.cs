using System;

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

        if (roleChoice == "1" && Login("Scout"))
        {
            ScoutMenu.ShowScoutMenu();
        }
        else if (roleChoice == "2" && Login("Tränare"))
        {
            CoachMenu.ShowCoachMenu();
        }
        else
        {
            Console.WriteLine("Felaktigt val eller inloggningsuppgifter. Programmet avslutas.");
        }
    }

    static bool Login(string role)
    {
        Console.WriteLine($"Ange användarnamn för {role}:");
        string username = Console.ReadLine();

        Console.WriteLine("Ange lösenord:");
        string password = Console.ReadLine();

        string correctUsername = role == "Scout" ? "Scout" : "Tränare";
        string correctPassword = role == "Scout" ? "scout123" : "coach123";

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
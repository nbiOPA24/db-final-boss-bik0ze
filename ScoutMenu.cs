using System;
using System.Collections.Generic;

// Scout-meny
static void ShowScoutMenu()
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

        // Hantera användarens val
        switch (choice)
        {
            case "1":
                // Funktionen för att lägga till en ny spelare
                AddPlayer();
                break;

            case "2":
                // Funktionen för att skapa en rapport för en spelare
                CreateReport();
                break;

            case "3":
                // Funktionen för att visa en lista över spelare
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

// Lägg till en ny spelare i listan
static void AddPlayer()
{
    Console.WriteLine("Ange spelarens namn:");
    string name = Console.ReadLine();

    Console.WriteLine("Ange spelarens ålder:");
    int age = int.Parse(Console.ReadLine());

    Console.WriteLine("Ange spelarens nationalitet:");
    string nationality = Console.ReadLine();

    Console.WriteLine("Skriv in spelarens längd:");
    int height = int.Parse(Console.ReadLine());

    Console.WriteLine("Skriv in spelarens vikt:");
    int weight = int.Parse(Console.ReadLine());

    Console.WriteLine("Skriv in spelarens position:");
    string position = Console.ReadLine();

    Console.WriteLine("Skriv in spelarens nuvarande klubb:");
    string team = Console.ReadLine();

    Console.WriteLine("Skriv in spelarens nuvarande liga:");
    string league = Console.ReadLine();

    // SQL-fråga för att lägga till spelaren
    string query = "INSERT INTO Players (Name, Age, Position, Team, League) VALUES (@Name, @Age, @Position, @Team, @League)";

    try
    {
        // Skapa en anslutning till databasen
        using (SqlConnection connection = DataManager.GetConnection())
        {
            connection.Open();

            // Skapa ett SQL-kommando och tilldela parametrar
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Position", position);
                command.Parameters.AddWithValue("@Team", team);
                command.Parameters.AddWithValue("@League", league);

                // Kör kommandot
                command.ExecuteNonQuery();
                Console.WriteLine("Spelaren har lagts till i databasen!");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fel vid inmatning av data: {ex.Message}");
    }
}



// Skapa en ny rapport för en spelare
static void CreateReport()
{
    Console.WriteLine("Ange spelarens namn för att skapa en rapport:");
    string name = Console.ReadLine();

    // Hitta spelaren i listan
    Player player = players.Find(p => p.Name == name);

    if (player != null)
    {
        Console.WriteLine("Ange betyg för snabbhet (1-10):");
        int speed = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg för uthållighet (1-10)");
        int stamina = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg för styrka (1-10)");
        int strength = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg för bollkontroll (1-10)");
        int ballcontrol = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg för passningar (1-10)");
        int passing = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg för dribblingar (1-10)");
        int dribbling = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg för avslut (1-10)");
        int finishing = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg för positionering (1-10)");
        int positioning = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg för spelintelligens");
        int gameintelligence = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange en kort observation om spelaren:");
        string observation = Console.ReadLine();

        // Skapa rapport och lägg till i spelarens rapportlista
        Report report = new Report
        {
            Speed = speed,
            Stamina = stamina,
            Strength = strength,
            BallControl = ballcontrol,
            Passing = passing,
            Dribbling = dribbling,
            Finishing = finishing,
            Positioning = positioning,
            GameIntelligence = gameintelligence,
            Observation = observation
        };

        player.Reports.Add(report);

        Console.WriteLine("Raport har lagts till för spelaren.");

    }
    else
    {
        Console.WriteLine("Spelaren kunde inte hittas.");
    }
}

// Metod för att lista spelare med grundläggande info och snittbetyg
static void ListPlayersForScouts()
{
    string query = "SELECT Name, Age, Position, Team, League FROM Players";

    try
    {
        // Skapa en anslutning till databasen
        using (SqlConnection connection = DataManager.GetConnection())
        {
            connection.Open();

            // Skapa och kör ett SQL-kommando
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Lista över spelare:");
                    while (reader.Read())
                    {
                        // Läs och visa data från databasen
                        Console.WriteLine($"Namn: {reader["Name"]}, Ålder: {reader["Age"]}, Position: {reader["Position"]}, Lag: {reader["Team"]}, Liga: {reader["League"]}");
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fel vid hämtning av data: {ex.Message}");
    }
}
using System;
using System.Collections.Generic;

// Scout-meny
static void ShowScoutMenu()
{
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("\nScout-meny:");
        Console.WriteLine("1. L�gg till ny spelare");
        Console.WriteLine("2. Skapa rapport f�r spelare");
        Console.WriteLine("3. Se lista �ver spelare");
        Console.WriteLine("4. Logga ut");

        string choice = Console.ReadLine();

        // Hantera anv�ndarens val
        switch (choice)
        {
            case "1":
                // Funktionen f�r att l�gga till en ny spelare
                AddPlayer();
                break;

            case "2":
                // Funktionen f�r att skapa en rapport f�r en spelare
                CreateReport();
                break;

            case "3":
                // Funktionen f�r att visa en lista �ver spelare
                ListPlayersForScouts();
                break;

            case "4":
                exit = true;
                Console.WriteLine("Loggar ut...");
                break;

            default:
                Console.WriteLine("Felaktigt val, f�rs�k igen.");
                break;
        }
    }
}

// L�gg till en ny spelare i listan
static void AddPlayer()
{
    Console.WriteLine("Ange spelarens namn:");
    string name = Console.ReadLine();

    Console.WriteLine("Ange spelarens �lder:");
    int age = int.Parse(Console.ReadLine());

    Console.WriteLine("Ange spelarens nationalitet:");
    string nationality = Console.ReadLine();

    Console.WriteLine("Skriv in spelarens l�ngd:");
    int height = int.Parse(Console.ReadLine());

    Console.WriteLine("Skriv in spelarens vikt:");
    int weight = int.Parse(Console.ReadLine());

    Console.WriteLine("Skriv in spelarens position:");
    string position = Console.ReadLine();

    Console.WriteLine("Skriv in spelarens nuvarande klubb:");
    string team = Console.ReadLine();

    Console.WriteLine("Skriv in spelarens nuvarande liga:");
    string league = Console.ReadLine();

    // SQL-fr�ga f�r att l�gga till spelaren
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

                // K�r kommandot
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



// Skapa en ny rapport f�r en spelare
static void CreateReport()
{
    Console.WriteLine("Ange spelarens namn f�r att skapa en rapport:");
    string name = Console.ReadLine();

    // Hitta spelaren i listan
    Player player = players.Find(p => p.Name == name);

    if (player != null)
    {
        Console.WriteLine("Ange betyg f�r snabbhet (1-10):");
        int speed = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg f�r uth�llighet (1-10)");
        int stamina = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg f�r styrka (1-10)");
        int strength = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg f�r bollkontroll (1-10)");
        int ballcontrol = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg f�r passningar (1-10)");
        int passing = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg f�r dribblingar (1-10)");
        int dribbling = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg f�r avslut (1-10)");
        int finishing = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg f�r positionering (1-10)");
        int positioning = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange betyg f�r spelintelligens");
        int gameintelligence = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange en kort observation om spelaren:");
        string observation = Console.ReadLine();

        // Skapa rapport och l�gg till i spelarens rapportlista
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

        Console.WriteLine("Raport har lagts till f�r spelaren.");

    }
    else
    {
        Console.WriteLine("Spelaren kunde inte hittas.");
    }
}

// Metod f�r att lista spelare med grundl�ggande info och snittbetyg
static void ListPlayersForScouts()
{
    string query = "SELECT Name, Age, Position, Team, League FROM Players";

    try
    {
        // Skapa en anslutning till databasen
        using (SqlConnection connection = DataManager.GetConnection())
        {
            connection.Open();

            // Skapa och k�r ett SQL-kommando
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Lista �ver spelare:");
                    while (reader.Read())
                    {
                        // L�s och visa data fr�n databasen
                        Console.WriteLine($"Namn: {reader["Name"]}, �lder: {reader["Age"]}, Position: {reader["Position"]}, Lag: {reader["Team"]}, Liga: {reader["League"]}");
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fel vid h�mtning av data: {ex.Message}");
    }
}
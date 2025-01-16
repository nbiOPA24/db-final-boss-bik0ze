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

    // Skapa en ny spelare och l�gg till i listan
    Player newPlayer = new Player
    {
        Name = name,
        Age = age,
        Nationality = nationality,
        Height = height,
        Weight = weight,
        Position = position,
        Team = team,
        League = league
    };

    players.Add(newPlayer);

    Console.WriteLine($"{name} har lagts till i listan.");

}

// // Skapa en ny rapport f�r en spelare
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
    if (players.Count == 0)
    {
        Console.WriteLine("Inga spelare har lagts till �nnu.");
    }

    Console.WriteLine("Lista �ver spelare:");
    for (int i = 0; i < players.Count; i++)
    {
        var player = players[i];
        double averageRating = player.Reports.Count > 0
        ? player.Reports.Average(r => (r.Speed + r.Stamina + r.Strength + r.BallControl + r.Passing + r.Dribbling + r.Finishing + r.Positioning + r.GameIntelligence) / 9.0)
        : 0;

        Console.WriteLine($"{i + 1}. Namn: {player.Name}, �lder: {player.Age}, Position: {player.Position}, Lag: {player.Team}, Liga: {player.League}, Snittbetyg: {averageRating:F1}");
    }

    Console.WriteLine("Ange numret p� spelaren du vill se mer information om, eller tryck Enter f�r att g� tillbaka:");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int playerIndex) && playerIndex > 0 && playerIndex <= players.Count)
    {
        ShowPlayerDetails(players[playerIndex - 1]);
    }
}
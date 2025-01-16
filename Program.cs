using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

class Program
{
    // Lista f�r att lagra spelare
    static List<Player> players = new List<Player>();

    static void Main(string[] args)
    {
        Console.WriteLine("V�lkommen till Scout Reports ND!");

        // L�s in spelardata fr�n JSON vid programmets start
        LoadPlayersFromJson();

        // Inloggningsmeny
        Console.WriteLine("V�lj din roll:");
        Console.WriteLine("1. Scout");
        Console.WriteLine("2. Tr�nare");
        string roleChoice = Console.ReadLine();

        // Hantera inloggning och navigera till respektive meny
        if (roleChoice == "1" && Login("Scout"))
        {
            ShowScoutMenu();
        }
        else if (roleChoice == "2" && Login("Tr�nare"))
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

    // Metod f�r att hantera inloggning
    static bool Login(string role)
    {
        // Best�m r�tt anv�ndarnamn och l�senord beroende p� roll
        string correctUsername = role == "Scout" ? "Scout" : "Tr�nare";
        string correctPassword = role == "Scout" ? "scout123" : "coach123";

        Console.WriteLine($"Ange anv�ndarnamn f�r {role}:");
        string username = Console.ReadLine();

        Console.WriteLine("Ange l�senord:");
        string password = Console.ReadLine();

        if (username == correctUsername && password == correctPassword)
        {
            Console.WriteLine("Inloggning lyckades!");
            return true;
        }
        else
        {
            Console.WriteLine("Felaktigt anv�ndarnamn eller l�senord.");
            return false;
        }
    }

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

    // Meny f�r tr�nare
    static void ShowCoachMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nTr�nar-meny:");
            Console.WriteLine("1. Visa lista �ver spelare");
            Console.WriteLine("2. S�k och filtrera spelare");
            Console.WriteLine("3. Hantera bevakningslista");
            Console.WriteLine("4. Logga ut");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListPlayersForCoach();
                    break;
                case "2":
                    // SearchAndFilterPlayers();
                    break;
                case "3":
                    // ManageWatchlist();
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

        // Spara data efter att spelaren har lagts till
        SavePlayersToJson();
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

            // Spara data efter att en rapport har lagts till
            SavePlayersToJson();
        }
        else
        {
            Console.WriteLine("Spelaren kunde inte hittas.");
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public string League { get; set; }
        public List<Report> Reports { get; set; } = new List<Report>();
    }

    public class Report
    {
        // Fysiska egenskaper
        public int Speed { get; set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }

        // Tekniska egenskaper
        public int BallControl { get; set; }
        public int Passing { get; set; }
        public int Dribbling { get; set; }
        public int Finishing { get; set; }

        // Taktiska egenskaper
        public int Positioning { get; set; }
        public int GameIntelligence { get; set; }

        // Scoutrapport
        public string Observation { get; set; }
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

    // Metod f�r att lista spelare f�r tr�nare
    static void ListPlayersForCoach()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Inga spelare har lagts till �nnu.");
            return;
        }

        Console.WriteLine("Lista �ver spelare f�r tr�naren:");
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

    // Metod f�r att visa detaljerad rapport f�r en specifik spelare
    static void ShowPlayerDetails(Player player)
    {
        Console.WriteLine($"\nDetaljerad rapport f�r {player.Name}:");
        Console.WriteLine($"�lder: {player.Age}, Position: {player.Position}, Lag: {player.Team}, Liga: {player.League}");
        Console.WriteLine("Rapporter:");

        if (player.Reports.Count == 0)
        {
            Console.WriteLine("Ingen rapport tillg�nglig.");
        }
        else
        {
            foreach (var report in player.Reports)
            {
                Console.WriteLine($"- Snabbhet: {report.Speed}, Uth�llighet: {report.Stamina}, Styrka: {report.Strength}, Bollkontroll: {report.BallControl}, Passningar: {report.Passing}, Dribblingar: {report.Dribbling}, Avslut: {report.Finishing}, Positionering: {report.Positioning}, Spelintelligens: {report.GameIntelligence}");
                Console.WriteLine($"  Observation: {report.Observation}");
                Console.WriteLine();
            }
        }
    }

    // Spara data till JSON-fil
    static void SavePlayersToJson()
    {
        string json = JsonSerializer.Serialize(players, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("players.json", json);
        Console.WriteLine("Spelardata har sparats.");
    }

    // Ladda data fr�n JSON-fil
    static void LoadPlayersFromJson()
    {
        if (File.Exists("players.json"))
        {
            string json = File.ReadAllText("players.json");
            players = JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
            Console.WriteLine("Spelardata har l�sts in.");
        }
        else
        {
            Console.WriteLine("Ingen tidigare data hittades.");
        }
    }

}
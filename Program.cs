using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

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

    // Meny för tränare
    static void ShowCoachMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nTränar-meny:");
            Console.WriteLine("1. Visa lista över spelare");
            Console.WriteLine("2. Sök och filtrera spelare");
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

        // Skapa en ny spelare och lägg till i listan
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

    // // Skapa en ny rapport för en spelare
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

    // Metod för att lista spelare med grundläggande info och snittbetyg
    static void ListPlayersForScouts()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Inga spelare har lagts till ännu.");
        }

        Console.WriteLine("Lista över spelare:");
        for (int i = 0; i < players.Count; i++)
        {
            var player = players[i];
            double averageRating = player.Reports.Count > 0
            ? player.Reports.Average(r => (r.Speed + r.Stamina + r.Strength + r.BallControl + r.Passing + r.Dribbling + r.Finishing + r.Positioning + r.GameIntelligence) / 9.0)
            : 0;

            Console.WriteLine($"{i + 1}. Namn: {player.Name}, Ålder: {player.Age}, Position: {player.Position}, Lag: {player.Team}, Liga: {player.League}, Snittbetyg: {averageRating:F1}");
        }

        Console.WriteLine("Ange numret på spelaren du vill se mer information om, eller tryck Enter för att gå tillbaka:");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int playerIndex) && playerIndex > 0 && playerIndex <= players.Count)
        {
            ShowPlayerDetails(players[playerIndex - 1]);
        }
    }

    // Metod för att lista spelare för tränare
    static void ListPlayersForCoach()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Inga spelare har lagts till ännu.");
            return;
        }

        Console.WriteLine("Lista över spelare för tränaren:");
        for (int i = 0; i < players.Count; i++)
        {
            var player = players[i];
            double averageRating = player.Reports.Count > 0
                ? player.Reports.Average(r => (r.Speed + r.Stamina + r.Strength + r.BallControl + r.Passing + r.Dribbling + r.Finishing + r.Positioning + r.GameIntelligence) / 9.0)
                : 0;

            Console.WriteLine($"{i + 1}. Namn: {player.Name}, Ålder: {player.Age}, Position: {player.Position}, Lag: {player.Team}, Liga: {player.League}, Snittbetyg: {averageRating:F1}");
        }

        Console.WriteLine("Ange numret på spelaren du vill se mer information om, eller tryck Enter för att gå tillbaka:");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int playerIndex) && playerIndex > 0 && playerIndex <= players.Count)
        {
            ShowPlayerDetails(players[playerIndex - 1]);
        }
    }

    // Metod för att visa detaljerad rapport för en specifik spelare
    static void ShowPlayerDetails(Player player)
    {
        Console.WriteLine($"\nDetaljerad rapport för {player.Name}:");
        Console.WriteLine($"Ålder: {player.Age}, Position: {player.Position}, Lag: {player.Team}, Liga: {player.League}");
        Console.WriteLine("Rapporter:");

        if (player.Reports.Count == 0)
        {
            Console.WriteLine("Ingen rapport tillgänglig.");
        }
        else
        {
            foreach (var report in player.Reports)
            {
                Console.WriteLine($"- Snabbhet: {report.Speed}, Uthållighet: {report.Stamina}, Styrka: {report.Strength}, Bollkontroll: {report.BallControl}, Passningar: {report.Passing}, Dribblingar: {report.Dribbling}, Avslut: {report.Finishing}, Positionering: {report.Positioning}, Spelintelligens: {report.GameIntelligence}");
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

    // Ladda data från JSON-fil
    static void LoadPlayersFromJson()
    {
        if (File.Exists("players.json"))
        {
            string json = File.ReadAllText("players.json");
            players = JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
            Console.WriteLine("Spelardata har lästs in.");
        }
        else
        {
            Console.WriteLine("Ingen tidigare data hittades.");
        }
    }

}
using System;
using System.Collections.Generic;

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
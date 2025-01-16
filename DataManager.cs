using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
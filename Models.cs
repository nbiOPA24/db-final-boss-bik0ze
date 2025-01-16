using System.Collections.Generic;

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
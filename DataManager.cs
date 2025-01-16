using System;
using Microsoft.Data.SqlClient;

public static class DataManager
{
    private static string connectionString = "Server=gondolin667.org;Database=yhstudent72_ScoutingReportsND;User Id=yhstudent72;Password=tpgYYzkb7U$g;Encrypt=True;TrustServerCertificate=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static bool TestDatabaseConnection()
    {
        using (var connection = GetConnection())
        {
            try
            {
                connection.Open();
                Console.WriteLine("Databasanslutning lyckades!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid anslutning till databasen: {ex.Message}");
                return false;
            }
        }
    }

    public static void AddPlayer()
    {
        Console.WriteLine("Ange spelarens namn:");
        string name = Console.ReadLine();

        Console.WriteLine("Ange spelarens ålder:");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange spelarens nationalitet:");
        string nationality = Console.ReadLine();

        Console.WriteLine("Ange spelarens längd (i cm):");
        int height = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange spelarens vikt (i kg):");
        int weight = int.Parse(Console.ReadLine());

        Console.WriteLine("Ange spelarens position:");
        string position = Console.ReadLine();

        Console.WriteLine("Ange spelarens klubb:");
        string team = Console.ReadLine();

        Console.WriteLine("Ange spelarens liga:");
        string league = Console.ReadLine();

        using (var connection = GetConnection())
        {
            string query = @"
            INSERT INTO Players (Name, Age, Nationality, Height, Weight, Position, Team, League) 
            VALUES (@Name, @Age, @Nationality, @Height, @Weight, @Position, @Team, @League)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Nationality", nationality);
                command.Parameters.AddWithValue("@Height", height);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Position", position);
                command.Parameters.AddWithValue("@Team", team);
                command.Parameters.AddWithValue("@League", league);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"{name} har lagts till i databasen.");
            }
        }
    }


    public static void CreateReport()
    {
        Console.WriteLine("Ange spelarens ID för att skapa en rapport:");
        int playerId = int.Parse(Console.ReadLine());

        using (var connection = GetConnection())
        {
            // Kontrollera om spelaren finns
            string checkQuery = "SELECT COUNT(*) FROM Players WHERE PlayerID = @PlayerID";
            using (var checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@PlayerID", playerId);
                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                connection.Close();

                if (count == 0)
                {
                    Console.WriteLine("Spelaren kunde inte hittas.");
                    return;
                }
            }

            // Samla in rapportdata
            Console.WriteLine("Ange betyg för snabbhet (1-10):");
            int speed = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange betyg för uthållighet (1-10):");
            int stamina = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange betyg för styrka (1-10):");
            int strength = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange betyg för bollkontroll (1-10):");
            int ballControl = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange betyg för passningar (1-10):");
            int passing = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange betyg för dribblingar (1-10):");
            int dribbling = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange betyg för avslut (1-10):");
            int finishing = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange betyg för positionering (1-10):");
            int positioning = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange betyg för spelintelligens (1-10):");
            int gameIntelligence = int.Parse(Console.ReadLine());

            Console.WriteLine("Ange en kort observation:");
            string observation = Console.ReadLine();

            // Spara rapporten
            string insertQuery = @"
            INSERT INTO Reports (PlayerID, Speed, Stamina, Strength, BallControl, Passing, Dribbling, Finishing, Positioning, GameIntelligence, Observation) 
            VALUES (@PlayerID, @Speed, @Stamina, @Strength, @BallControl, @Passing, @Dribbling, @Finishing, @Positioning, @GameIntelligence, @Observation)";

            using (var command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@PlayerID", playerId);
                command.Parameters.AddWithValue("@Speed", speed);
                command.Parameters.AddWithValue("@Stamina", stamina);
                command.Parameters.AddWithValue("@Strength", strength);
                command.Parameters.AddWithValue("@BallControl", ballControl);
                command.Parameters.AddWithValue("@Passing", passing);
                command.Parameters.AddWithValue("@Dribbling", dribbling);
                command.Parameters.AddWithValue("@Finishing", finishing);
                command.Parameters.AddWithValue("@Positioning", positioning);
                command.Parameters.AddWithValue("@GameIntelligence", gameIntelligence);
                command.Parameters.AddWithValue("@Observation", observation);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Rapporten har sparats.");
            }
        }
    }

    public static void ShowPlayerReports(int playerId)
    {
        using (var connection = GetConnection())
        {
            // Hämta spelarens grundläggande information
            string playerQuery = "SELECT Name, Age, Position, Team FROM Players WHERE PlayerID = @PlayerID";
            using (var playerCommand = new SqlCommand(playerQuery, connection))
            {
                playerCommand.Parameters.AddWithValue("@PlayerID", playerId);
                connection.Open();
                using (var reader = playerCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("\nSpelarinformation:");
                        Console.WriteLine($"  Namn: {reader["Name"]}");
                        Console.WriteLine($"  Ålder: {reader["Age"]}");
                        Console.WriteLine($"  Position: {reader["Position"]}");
                        Console.WriteLine($"  Lag: {reader["Team"]}");
                    }
                    else
                    {
                        Console.WriteLine("Spelaren kunde inte hittas.");
                        return;
                    }
                }
                connection.Close();
            }

            // Hämta spelarens rapporter
            string reportQuery = @"
            SELECT Speed, Stamina, Strength, BallControl, Passing, Dribbling, Finishing, Positioning, GameIntelligence, Observation 
            FROM Reports 
            WHERE PlayerID = @PlayerID";

            using (var reportCommand = new SqlCommand(reportQuery, connection))
            {
                reportCommand.Parameters.AddWithValue("@PlayerID", playerId);
                connection.Open();
                using (var reader = reportCommand.ExecuteReader())
                {
                    Console.WriteLine("\nRapporter:");
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Inga rapporter hittades för denna spelare.");
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine("Rapport:");
                        Console.WriteLine($"  Snabbhet: {reader["Speed"]}");
                        Console.WriteLine($"  Uthållighet: {reader["Stamina"]}");
                        Console.WriteLine($"  Styrka: {reader["Strength"]}");
                        Console.WriteLine($"  Bollkontroll: {reader["BallControl"]}");
                        Console.WriteLine($"  Passningar: {reader["Passing"]}");
                        Console.WriteLine($"  Dribbling: {reader["Dribbling"]}");
                        Console.WriteLine($"  Avslut: {reader["Finishing"]}");
                        Console.WriteLine($"  Positionering: {reader["Positioning"]}");
                        Console.WriteLine($"  Spelintelligens: {reader["GameIntelligence"]}");
                        Console.WriteLine($"  Observation: {reader["Observation"]}");
                        Console.WriteLine("---------------------------");
                    }
                }
            }
        }
    }
}
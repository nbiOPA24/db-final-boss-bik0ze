/*class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=gondolin667.org;Database=yhstudent72_ScoutingReportsND;User Id=yhstudent72;Password=tpgYYzkb7U$g;Encrypt=True;TrustServerCertificate=True;";


        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Anslutningen till databasen lyckades!");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
            Console.WriteLine("Felsökningsdetaljer:");
            foreach (SqlError error in ex.Errors)
            {
                Console.WriteLine($"- Felnummer: {error.Number}, Meddelande: {error.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Anslutningen misslyckades: {ex.Message}");
        }
    }
}*/

/*
using Microsoft.Data.SqlClient; // För SQL-anslutningar


public static class DataManager
{
    // Anslutningssträng för databasen
    private static string connectionString = "Server=gondolin667.org;Database=yhstudent72_ScoutingReportsND;User Id=yhstudent72;Password=tpgYYzkb7U$g;Encrypt=True;TrustServerCertificate=True;";

    // Metod för att skapa och returnera en SQL-anslutning
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}*/
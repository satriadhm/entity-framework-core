using Data;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            using DBConnection dbConnection = DBConnection.Instance();

            if (dbConnection.Connection != null)
            {
                Console.WriteLine("Connection established successfully!");
            }
            else
            {
                Console.WriteLine("Failed to establish a connection.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

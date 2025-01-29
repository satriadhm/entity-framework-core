using CSharpImplementation;
using Data;
using System.Data.Common;

internal class Program
{
    private static void Main(string[] args)
    {

        DBConnection dBConnection = DBConnection.Instance();

        dBConnection.Server = "localhost";
        dBConnection.DatabaseName = "modul15";
        dBConnection.UserName = "root";
        dBConnection.Password = "satria2133";


        if (dBConnection.IsConnect())
        {
            Console.WriteLine("Connection established successfully!");


            dBConnection.Close();
            Console.WriteLine("Connection closed.");
        }
        else
        {
            Console.WriteLine("Failed to establish a connection.");
        }
    }
}
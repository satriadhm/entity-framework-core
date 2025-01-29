using MySql.Data.MySqlClient;
using dotenv.net;
using System;
using System.Collections.Generic;

namespace Data
{
    public class DBConnection : IDisposable
    {
        private static DBConnection? _instance;
        private MySqlConnection? _connection;

        private DBConnection() { }

        public static DBConnection Instance()
        {
            return _instance ??= new DBConnection();
        }

        public MySqlConnection? Connection
        {
            get
            {
                if (_connection == null)
                {
                    DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "./.env" }));

                    IDictionary<string, string> envVars = DotEnv.Read();
                    Console.WriteLine("Loaded environment variables:");
                    foreach (var kvp in envVars)
                    {
                        Console.WriteLine($"{kvp.Key} = {kvp.Value}");
                    }

                    string server = envVars["DB_SERVER"];
                    string database = envVars["DB_NAME"];
                    string user = envVars["DB_USER"];
                    string password = envVars["DB_PASSWORD"];

                    string connString = $"Server={server};Database={database};User={user};Password={password};SslMode=none;";
                    _connection = new MySqlConnection(connString);
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Close()
        {
            _connection?.Close();
            _connection = null;
        }

        public void Dispose()
        {
            Close();
        }
    }
}

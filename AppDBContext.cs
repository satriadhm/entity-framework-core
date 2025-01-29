using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using dotenv.net;
using System;
using System.Collections.Generic;

namespace CSharpImplementation
{
    public class AppDBContext : DbContext
    {
        public DbSet<DBModel> DBModels { get; set; }

        // Constructor for Dependency Injection
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        // Parameterless constructor required for `dotnet ef` migrations
        public AppDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                try
                {
                    // Load environment variables
                    DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "./.env" }));
                    IDictionary<string, string> envVars = DotEnv.Read();

                    // Validate environment variables
                    if (!envVars.ContainsKey("DB_SERVER") || !envVars.ContainsKey("DB_NAME") ||
                        !envVars.ContainsKey("DB_USER") || !envVars.ContainsKey("DB_PASSWORD"))
                    {
                        throw new Exception("Missing required database configuration in .env file.");
                    }

                    string server = envVars["DB_SERVER"];
                    string database = envVars["DB_NAME"];
                    string user = envVars["DB_USER"];
                    string password = envVars["DB_PASSWORD"];

                    string connectionString = $"Server={server};Database={database};User={user};Password={password};SslMode=none;";

                    // Ensure correct `UseMySql` syntax and ServerVersion detection
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading database configuration: {ex.Message}");
                    throw;
                }
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using dotenv.net;
using System.Collections.Generic;
using System;

namespace CSharpImplementation
{
    internal class AppDBContext : DbContext
    {
        public DbSet<DBModel> DBModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Load environment variables
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "./.env" }));
            IDictionary<string, string> envVars = DotEnv.Read();

            string server = envVars["DB_SERVER"];
            string database = envVars["DB_NAME"];
            string user = envVars["DB_USER"];
            string password = envVars["DB_PASSWORD"];

            string connectionString = $"Server={server};Database={database};User={user};Password={password};SslMode=none;";
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}

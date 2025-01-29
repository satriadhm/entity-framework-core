using Microsoft.Extensions.DependencyInjection;
using CSharpImplementation;
using dotenv.net;
using System;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Starting application...");

            // Load .env
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "./.env" }));
            Console.WriteLine("Environment variables loaded successfully.");

            // Setup Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDBContext>()
                .AddScoped<IDBRepository<DBModel>, DBService>()
                .BuildServiceProvider();

            Console.WriteLine("Dependency Injection initialized.");

            var service = serviceProvider.GetService<IDBRepository<DBModel>>();

            if (service == null)
            {
                Console.WriteLine("Service initialization failed! Check DI configuration.");
                return;
            }

            Console.WriteLine("CRUD Service initialized successfully!");

            // Run CRUD operations
            RunCRUDOperations(service).Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task RunCRUDOperations(IDBRepository<DBModel> service)
    {
        try
        {
            Console.WriteLine("Running CRUD operations...");

            // Create
            var newModel = new DBModel { Id = "ABC", Name = "Test Model", Type = "Example", Info = "Test info" };
            await service.Add(newModel);
            Console.WriteLine("Data created successfully!");

            // Read
            var allModels = await service.GetAllSync();
            Console.WriteLine("List of Data:");
            foreach (var model in allModels)
            {
                Console.WriteLine($"ID: {model.Id}, Name: {model.Name}, Type: {model.Type}, Info: {model.Info}");
            }

            // Update
            var firstModel = await service.GetById(newModel.Id);
            var newEntity = new DBModel { Name = "Updated Name", Type = "Updated Type", Info = "Updated Info" };
            if (firstModel != null)
            {
                await service.Update(firstModel.Id.ToString(), newEntity);
                Console.WriteLine("Data updated successfully!");
            }

            // Delete
            await service.DeleteById(newModel.Id);
            Console.WriteLine("Data deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during CRUD operations: {ex.Message}");
        }
    }
}

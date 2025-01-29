using Microsoft.Extensions.DependencyInjection;
using CSharpImplementation;
using dotenv.net;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            // Load .env
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "./.env" }));

            // Setup Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDBContext>()
                .AddScoped<IDBRepository<DBModel>, DBService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<IDBRepository<DBModel>>();

            if (service == null)
            {
                Console.WriteLine("Service initialization failed!");
                return;
            }

            Console.WriteLine("CRUD Service initialized successfully!");

            // CRUD Testing
            RunCRUDOperations(service).Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task RunCRUDOperations(IDBRepository<DBModel> service)
    {
        // Create
        var newModel = new DBModel {Id = "ABC", Name = "Test Model", Type = "Example", Info = "Test info" };
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
        var newEntity = new DBModel { Name = "Trying to change", Info = "Changing info", Type = "Also changing type" };
        if (firstModel != null)
        {
            firstModel.Info = "Updated info";
            await service.Update(firstModel.Id.ToString(), newEntity);
            Console.WriteLine("Data updated successfully!");
        }

        // Delete
        await service.DeleteById(newModel.Id);
        Console.WriteLine("Data deleted successfully!");
    }
}

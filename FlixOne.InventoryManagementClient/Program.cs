using FlixOne.InventoryManagement;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementClient; // Note: actual namespace depends on the project name.



internal class Program
{
    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();

        ConfigureServices(services);

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        var service = serviceProvider.GetRequiredService<ICatalogService>();

        service.Run();

        Console.WriteLine("CatalogService has completed.");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Добавляем сервисы приложения
        services.AddTransient<IUserInterface, ConsoleUserInterface>();
        services.AddTransient<ICatalogService, CatalogService>();
        services.AddTransient<IInventoryCommandFactory, InventoryCommandFactory>();
    }
}
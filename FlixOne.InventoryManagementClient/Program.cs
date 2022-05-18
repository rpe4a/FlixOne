using FlixOne.InventoryManagement;
using FlixOne.InventoryManagement.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementClient;
// Note: actual namespace depends on the project name.

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
        services.AddTransient<InventoryCommand, QuitCommand>();
        services.AddTransient<InventoryCommand, HelpCommand>();
        services.AddTransient<InventoryCommand, AddInventoryCommand>();
        services.AddTransient<InventoryCommand, GetInventoryCommand>();
        services.AddTransient<InventoryCommand, UpdateQuantityCommand>();
        // UnknownCommand должна регистрироваться последней, т.к. определяет поведение по умолчанию
        services.AddTransient<InventoryCommand, UnknownCommand>();
        services.AddTransient<Func<string, InventoryCommand>>(s =>
            input => s.GetServices<InventoryCommand>().First(ser => ser.IsCommandFor(input)));

        var context = new InventoryContext();
        services.AddSingleton<IInventoryReadContext, InventoryContext>(p => context);
        services.AddSingleton<IInventoryWriteContext, InventoryContext>(p => context);
        services.AddSingleton<IInventoryContext, InventoryContext>(p => context);
    }
}
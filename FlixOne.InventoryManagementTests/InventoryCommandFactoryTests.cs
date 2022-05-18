using System.Linq;
using FlixOne.InventoryManagement;
using FlixOne.InventoryManagement.Commands;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace FlixOne.InventoryManagementTests;

public class InventoryCommandFactoryTests
{
    public InventoryCommandFactoryTests()
    {
        var context = new InventoryContext();
        
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<IUserInterface, ConsoleUserInterface>();
        services.AddSingleton<IInventoryReadContext, InventoryContext>(p => context);
        services.AddSingleton<IInventoryWriteContext, InventoryContext>(p => context);
        services.AddSingleton<IInventoryContext, InventoryContext>(p => context);
        services.AddTransient<InventoryCommand, QuitCommand>();
        services.AddTransient<InventoryCommand, HelpCommand>();
        services.AddTransient<InventoryCommand, AddInventoryCommand>();
        services.AddTransient<InventoryCommand, GetInventoryCommand>();
        services.AddTransient<InventoryCommand, UpdateQuantityCommand>();
        // UnknownCommand должна регистрироваться последней
        services.AddTransient<InventoryCommand, UnknownCommand>();
       
        Services = services.BuildServiceProvider();
    }

    public ServiceProvider Services { get; set; }

    [Fact]
    public void QuitCommand_Successful()
    {
        Assert.IsType<QuitCommand>(GetCommand("q"));
        Assert.IsType<QuitCommand>(GetCommand("quit"));
    }

    [Fact]
    public void HelpCommand_Successful()
    {
        Assert.IsType<HelpCommand>(GetCommand("?"));
    }

    [Fact]
    public void UnknownCommand_Successful()
    {
        Assert.IsType<UnknownCommand>(GetCommand("add"));
        Assert.IsType<UnknownCommand>(GetCommand("addinventry"));
        Assert.IsType<UnknownCommand>(GetCommand("h"));
        Assert.IsType<UnknownCommand>(GetCommand("help"));
    }

    [Fact]
    public void UpdateQuantityCommand_Successful()
    {
        Assert.IsType<UpdateQuantityCommand>(GetCommand("u"));
        Assert.IsType<UpdateQuantityCommand>(GetCommand("updatequantity"));
        Assert.IsType<UpdateQuantityCommand>(GetCommand("UpdaTEQuantity"));
    }

    public InventoryCommand GetCommand(string input)
    {
        return Services.GetServices<InventoryCommand>().First(svc =>
            svc.IsCommandFor(input));
    }
}
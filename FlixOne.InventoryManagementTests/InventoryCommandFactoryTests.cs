using FlixOne.InventoryManagement;
using FlixOne.InventoryManagement.Commands;
using NSubstitute;
using Xunit;

namespace FlixOne.InventoryManagementTests;

public class InventoryCommandFactoryTests
{
    public InventoryCommandFactoryTests()
    {
        var @interface = Substitute.For<IUserInterface>();
        Factory = new InventoryCommandFactory(@interface);
    }

    public InventoryCommandFactory Factory { get; set; }


    [Fact]
    public void QuitCommand_Successful()
    {
        Assert.IsType<QuitCommand>(Factory.GetCommand("q"));
        Assert.IsType<QuitCommand>(Factory.GetCommand("quit"));
    }

    [Fact]
    public void HelpCommand_Successful()
    {
        Assert.IsType<HelpCommand>(Factory.GetCommand("?"));
    }

    [Fact]
    public void UnknownCommand_Successful()
    {
        Assert.IsType<UnknownCommand>(Factory.GetCommand("add"));
        Assert.IsType<UnknownCommand>(Factory.GetCommand("addinventry"));
        Assert.IsType<UnknownCommand>(Factory.GetCommand("h"));
        Assert.IsType<UnknownCommand>(Factory.GetCommand("help"));
    }

    [Fact]
    public void UpdateQuantityCommand_Successful()
    {
        Assert.IsType<UpdateQuantityCommand>(Factory.GetCommand("u"));
        Assert.IsType<UpdateQuantityCommand>(Factory.GetCommand("updatequantity"));
        Assert.IsType<UpdateQuantityCommand>(Factory.GetCommand("UpdaTEQuantity"));
    }


}
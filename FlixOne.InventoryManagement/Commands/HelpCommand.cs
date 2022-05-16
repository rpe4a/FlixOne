namespace FlixOne.InventoryManagement.Commands;

internal class HelpCommand : NonTerminatingCommand
{
    protected override bool InternalCommand()
    {
        Console.WriteLine("USAGE:");
        Console.WriteLine("\taddinventory (a)");
        //...
        Console.WriteLine("Examples:");
        //...
        return true;
    }

    public HelpCommand(IUserInterface userInterface) : base(userInterface)
    {   
    }
}
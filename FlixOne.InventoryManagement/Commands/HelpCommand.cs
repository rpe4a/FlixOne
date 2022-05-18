namespace FlixOne.InventoryManagement.Commands;

public class HelpCommand : NonTerminatingCommand
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

    protected override string[] CommandStrings { get; } = { "?" };

    public HelpCommand(IUserInterface userInterface) : base(userInterface)
    {
    }
}
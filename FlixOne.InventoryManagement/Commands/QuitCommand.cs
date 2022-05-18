namespace FlixOne.InventoryManagement.Commands;

public class QuitCommand : InventoryCommand
{
    public QuitCommand(IUserInterface userInterface) : base(userInterface, true)
    {
    }

    protected override bool InternalCommand()
    {
        Interface.WriteMessage("Thank you for using FlixOne Inventory Management System");
        return true;
    }

    protected override string[] CommandStrings { get; } = new[] { "q", "quit" };
}
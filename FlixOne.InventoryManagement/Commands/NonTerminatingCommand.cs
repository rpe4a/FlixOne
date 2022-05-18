namespace FlixOne.InventoryManagement.Commands;

public  abstract class NonTerminatingCommand : InventoryCommand
{
    protected NonTerminatingCommand(IUserInterface userInterface) : base(userInterface, false)
    {
    }
}
namespace FlixOne.InventoryManagement.Commands;

internal abstract class NonTerminatingCommand : InventoryCommand
{
    protected NonTerminatingCommand(IUserInterface userInterface) : base(userInterface, false)
    {
    }
}
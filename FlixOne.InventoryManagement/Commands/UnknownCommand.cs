namespace FlixOne.InventoryManagement.Commands;

internal class UnknownCommand : NonTerminatingCommand
{
    protected override bool InternalCommand()
    {
        Interface.WriteWarning("Unable to determine the desired command.");
        
        return false;
    }

    public UnknownCommand(IUserInterface userInterface) : base(userInterface)
    {
    }
}
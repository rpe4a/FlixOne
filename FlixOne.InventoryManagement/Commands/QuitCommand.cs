namespace FlixOne.InventoryManagement.Commands;

internal class QuitCommand : InventoryCommand
{
    internal QuitCommand(IUserInterface userInterface) : base(userInterface, true)
    {
    }

    protected override bool InternalCommand()
    {
        Interface.WriteMessage("Thank you for using FlixOne Inventory Management System");
        return true;
    }
}
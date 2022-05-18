namespace FlixOne.InventoryManagement.Commands;

public class UnknownCommand : NonTerminatingCommand
{
    protected override bool InternalCommand()
    {
        Interface.WriteWarning("Unable to determine the desired command.");

        return false;
    }

    protected override string[] CommandStrings { get; } = new string[0];

    public UnknownCommand(IUserInterface userInterface) : base(userInterface)
    {
    }

    public override bool IsCommandFor(string input) => true;
}
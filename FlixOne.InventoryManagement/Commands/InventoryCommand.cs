namespace FlixOne.InventoryManagement.Commands;

public abstract class InventoryCommand
{
    protected readonly IUserInterface Interface;
    private readonly bool _isTerminatingCommand;

    protected InventoryCommand(IUserInterface @interface, bool commandIsTerminating)
    {
        Interface = @interface;
        _isTerminatingCommand = commandIsTerminating;
    }

    public (bool wasSuccessful, bool shouldQuit) RunCommand()
    {
        if (this is IParameterisedCommand parameterisedCommand)
        {
            var allParametersCompleted = false;

            while (allParametersCompleted == false)
            {
                allParametersCompleted = parameterisedCommand.GetParameters();
            }
        }

        return (InternalCommand(), _isTerminatingCommand);
    }

    protected abstract bool InternalCommand();

    internal string GetParameter(string parameterName)
    {
        return Interface.ReadValue($"Enter {parameterName}:");
    }
}
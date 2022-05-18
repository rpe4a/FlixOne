using FlixOne.InventoryManagement.Commands;

namespace FlixOne.InventoryManagement;

public class CatalogService : ICatalogService
{
    private readonly IUserInterface _userInterface;
    private readonly Func<string, InventoryCommand> _commandFactory;


    public CatalogService(IUserInterface userInterface, Func<string, InventoryCommand> commandFactory)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
    }

    public void Run()
    {
        var response = _commandFactory("?").RunCommand();
        while (!response.shouldQuit)
        {
            // посмотрите на ошибку с ToLower()
            var input = _userInterface.ReadValue("> ").ToLower();

            var command = _commandFactory(input);

            response = command.RunCommand();
            if (!response.wasSuccessful)
            {
                _userInterface.WriteMessage("Enter ? to view options.");
            }
        }
    }
}
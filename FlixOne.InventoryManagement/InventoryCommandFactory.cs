using FlixOne.InventoryManagement.Commands;

namespace FlixOne.InventoryManagement;

public class InventoryCommandFactory : IInventoryCommandFactory
{
    private readonly IUserInterface _userInterface;
    private readonly IInventoryContext _context = InventoryContext.Singleton;

    public InventoryCommandFactory(IUserInterface userInterface)
    {
        _userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
    }

    public InventoryCommand GetCommand(string input)
    {
        switch (input.ToLower())
        {
            case "q":
            case "quit":
                return new QuitCommand(_userInterface);
            case "a":
            case "addinventory":
                return new AddInventoryCommand(_context, _userInterface);
            case "g":
            case "getinventory":
                return new GetInventoryCommand(_context, _userInterface);
            case "u":
            case "updatequantity":
                return new UpdateQuantityCommand(_context, _userInterface);
            case "?":
                return new HelpCommand(_userInterface);
            default:
                return new UnknownCommand(_userInterface);
        }
    }
}
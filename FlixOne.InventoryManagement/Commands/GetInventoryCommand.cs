namespace FlixOne.InventoryManagement.Commands;

public class GetInventoryCommand : NonTerminatingCommand
{
    private readonly IInventoryReadContext _context;

    protected override bool InternalCommand()
    {
        foreach (var book in _context.GetBooks())
        {
            Interface.WriteMessage($"{book.Name,-30}\tQuantity:{book.Quantity}");
        }

        return true;
    }

    protected override string[] CommandStrings { get; } = new[] { "g", "getinventory" };

    public GetInventoryCommand(IInventoryReadContext context, IUserInterface userInterface) : base(userInterface)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
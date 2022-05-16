namespace FlixOne.InventoryManagement.Commands;

internal class GetInventoryCommand : NonTerminatingCommand
{
    private readonly IInventoryContext _context;

    protected override bool InternalCommand()
    {
        foreach (var book in _context.GetBooks())
        {
            Interface.WriteMessage($"{book.Name,-30}\tQuantity:{book.Quantity}");
        }

        return true;
    }

    public GetInventoryCommand(IInventoryContext context, IUserInterface userInterface) : base(userInterface)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
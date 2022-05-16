namespace FlixOne.InventoryManagement.Commands;

internal class UpdateQuantityCommand : NonTerminatingCommand, IParameterisedCommand
{
    private readonly IInventoryContext _context;

    internal string InventoryName { get; private set; }

    private int _quantity;
    internal int Quantity
    {
        get => _quantity;
        private set => _quantity = value;
    }

    protected override bool InternalCommand()
    {
        return _context.UpdateQuantity(InventoryName, Quantity);
    }

    public UpdateQuantityCommand(IInventoryContext context, IUserInterface userInterface) : base(userInterface)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool GetParameters()
    {
        if (string.IsNullOrWhiteSpace(InventoryName))
            InventoryName = GetParameter("name");

        if (Quantity == 0)
            int.TryParse(GetParameter("quantity"), out _quantity);

        return !string.IsNullOrWhiteSpace(InventoryName) && Quantity != 0;
    }
}
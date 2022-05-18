namespace FlixOne.InventoryManagement.Commands;

public class UpdateQuantityCommand : NonTerminatingCommand, IParameterisedCommand
{
    private readonly IInventoryWriteContext _context;

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

    protected override string[] CommandStrings { get; } = new[] { "u", "updatequantity" };

    public UpdateQuantityCommand(IInventoryWriteContext context, IUserInterface userInterface) : base(userInterface)
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
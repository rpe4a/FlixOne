namespace FlixOne.InventoryManagement.Commands;

internal class AddInventoryCommand : NonTerminatingCommand, IParameterisedCommand
{
    private readonly IInventoryContext _context;

    public AddInventoryCommand(IInventoryContext context, IUserInterface userInterface) : base(userInterface)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public string InventoryName { get; private set; }

    /// <summary>
    /// AddInventoryCommand requires name
    /// </summary>
    /// <returns></returns>
    public bool GetParameters()
    {
        if (string.IsNullOrEmpty(InventoryName))
            InventoryName = GetParameter("name");

        return !string.IsNullOrEmpty(InventoryName);
    }


    protected override bool InternalCommand()
    {
        return _context.AddBook(InventoryName);
    }
}
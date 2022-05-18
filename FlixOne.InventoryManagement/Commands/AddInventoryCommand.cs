namespace FlixOne.InventoryManagement.Commands;

public class AddInventoryCommand : NonTerminatingCommand, IParameterisedCommand
{
    private readonly IInventoryWriteContext _context;

    public AddInventoryCommand(IInventoryWriteContext context, IUserInterface userInterface) : base(userInterface)
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

    protected override string[] CommandStrings { get; } = new[] { "a", "addinventory" };
}
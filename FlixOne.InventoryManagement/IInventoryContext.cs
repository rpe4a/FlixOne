namespace FlixOne.InventoryManagement;

public interface IInventoryContext : IInventoryReadContext,
    IInventoryWriteContext
{
}

public interface IInventoryReadContext
{
    Book[] GetBooks();
}

public interface IInventoryWriteContext
{
    bool AddBook(string name);
    bool UpdateQuantity(string name, int quantity);
}
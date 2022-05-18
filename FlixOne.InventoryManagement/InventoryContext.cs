using System.Collections.Concurrent;

namespace FlixOne.InventoryManagement;

public class InventoryContext : IInventoryContext
{
    private readonly object _locker = new object();

    public InventoryContext()
    {
        _books = new ConcurrentDictionary<string, Book>();
    }

    private readonly IDictionary<string, Book> _books;

    public Book[] GetBooks()
    {
        return _books.Values.ToArray();
    }

    public bool AddBook(string name)
    {
        _books.Add(name, new Book { Name = name });
        return true;
    }

    public bool UpdateQuantity(string name, int quantity)
    {
        var book = _books[name];

        lock (_locker)
        {
            book.Quantity += quantity;
        }

        return true;
    }
}
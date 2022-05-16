namespace FlixOne.InventoryManagement;

public class ConsoleUserInterface : IUserInterface
{
    // чтение значения из консоли
    public string ReadValue(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(message);
        return Console.ReadLine();
    }

    // сообщение в консоль
    public void WriteMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
    }

    // вывод предупреждения в консоль
    public void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
    }
}
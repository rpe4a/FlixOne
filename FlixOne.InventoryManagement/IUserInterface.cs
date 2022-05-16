namespace FlixOne.InventoryManagement;

public interface IUserInterface : IReadUserInterface, IWriteUserInterface
{
}

public interface IReadUserInterface
{
    string ReadValue(string message);
}

public interface IWriteUserInterface
{
    void WriteMessage(string message);
    void WriteWarning(string message);
}
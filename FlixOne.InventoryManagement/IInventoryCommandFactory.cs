using FlixOne.InventoryManagement.Commands;

namespace FlixOne.InventoryManagement;

public interface IInventoryCommandFactory
{
    InventoryCommand GetCommand(string input);
}
using System.Threading.Tasks;

namespace CQRS.Base.Standard
{
	public interface ICommandProcessor
	{
		Task ProcessAsync<TCommand>(TCommand command) where TCommand : ICommand;
		void Process<TCommand>(TCommand command) where TCommand : ICommand;
	}
}

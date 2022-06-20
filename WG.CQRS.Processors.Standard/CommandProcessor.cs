using System.Threading.Tasks;
using CQRS.Base.Standard;
using SimpleInjector;

namespace CQRS.Processors.Standard
{
	public class CommandProcessor : ICommandProcessor
	{
		private readonly Container _container;

		public CommandProcessor(Container container)
		{
			_container = container;
		}

		public void Process<TCommand>(TCommand command) where TCommand : ICommand
		{
			var handler = GetCommandHandler(command);
			handler.Handle(command);
		}

		public Task ProcessAsync<TCommand>(TCommand command) where TCommand : ICommand
		{
			var handler = GetCommandHandler(command);
			return handler.HandleAsync(command);
		}

		private ICommandHandler<TCommand> GetCommandHandler<TCommand>(TCommand command) where TCommand : ICommand
		{
			var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
			var handler = (ICommandHandler<TCommand>)_container.GetInstance(handlerType);
			return handler;
		}
	}
}

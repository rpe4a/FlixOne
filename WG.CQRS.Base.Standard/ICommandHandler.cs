using System.Threading.Tasks;

namespace CQRS.Base.Standard
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task HandleAsync(TCommand command)
		{
			Utils.MethodShouldBeImplemented(nameof(HandleAsync));
			return Task.CompletedTask;
		}

		void Handle(TCommand command)
		{
			Utils.MethodShouldBeImplemented(nameof(Handle));
		}
	}
}

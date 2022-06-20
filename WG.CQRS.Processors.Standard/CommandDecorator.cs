using System.Threading.Tasks;
using CQRS.Base.Standard;

namespace CQRS.Processors.Standard
{
	public abstract class CommandDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
	{
		protected ICommandHandler<TCommand> Decoratee { get; set; }

		protected CommandDecorator(ICommandHandler<TCommand> decoratee)
		{
			Decoratee = decoratee;
		}

		public virtual async Task HandleAsync(TCommand command)
		{
			await BeforeHandleAsync(command);
			await Decoratee.HandleAsync(command);
			await AfterHandleAsync(command);
		}

		protected virtual Task BeforeHandleAsync(TCommand command)
		{
			return Task.CompletedTask;
		}

		protected virtual Task AfterHandleAsync(TCommand command)
		{
			return Task.CompletedTask;
		}

		public void Handle(TCommand command)
		{
			BeforeHandle(command);
			Decoratee.Handle(command);
			AfterHandle(command);
		}

		protected virtual void BeforeHandle(TCommand command)
		{
		}

		protected virtual void AfterHandle(TCommand command)
		{
		}
	}
}

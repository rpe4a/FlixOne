using System.Threading.Tasks;

namespace CQRS.Base.Standard
{
	public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
	{
		Task<TResult> HandleAsync(TQuery query)
		{
			Utils.MethodShouldBeImplemented(nameof(HandleAsync));
			return Task.FromResult<TResult>(default);
		}

		TResult Handle(TQuery query)
		{
			Utils.MethodShouldBeImplemented(nameof(Handle));
			return default;
		}
	}
}

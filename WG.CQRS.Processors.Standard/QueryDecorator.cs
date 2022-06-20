using System.Threading.Tasks;
using CQRS.Base.Standard;

namespace CQRS.Processors.Standard
{
	public abstract class QueryDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
	{
		protected IQueryHandler<TQuery, TResult> Decoratee { get; set; }

		protected QueryDecorator(IQueryHandler<TQuery, TResult> decoratee)
		{
			Decoratee = decoratee;
		}

		public virtual async Task<TResult> HandleAsync(TQuery query)
		{
			await BeforeHandleAsync(query);
			var result = await Decoratee.HandleAsync(query);
			return await AfterHandleAsync(query, result);
		}

		protected virtual Task BeforeHandleAsync(TQuery query)
		{
			return Task.CompletedTask;
		}

		protected virtual Task<TResult> AfterHandleAsync(TQuery query, TResult decorateeResult)
		{
			return Task.FromResult(decorateeResult);
		}

		public TResult Handle(TQuery query)
		{
			BeforeHandleAsync(query);
			var result = Decoratee.Handle(query);
			return AfterHandle(query, result);
		}

		protected virtual void BeforeHandle(TQuery query)
		{
		}

		protected virtual TResult AfterHandle(TQuery query, TResult decorateeResult)
		{
			return decorateeResult;
		}
	}
}

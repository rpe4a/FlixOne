using System.Threading.Tasks;
using CQRS.Base.Standard;
using SimpleInjector;

namespace CQRS.Processors.Standard
{
	public class QueryProcessor : IQueryProcessor
	{
		private readonly Container _container;

		public QueryProcessor(Container container)
		{
			_container = container;
		}

		public TResult Process<TResult>(IQuery<TResult> query)
		{
			var handler = GetQueryHandler(query);
			return handler.Handle(query);
		}

		public Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query)
		{
			var handler = GetQueryHandler(query);
			return handler.HandleAsync(query);
		}

		private  IQueryHandler<IQuery<TResult>, TResult> GetQueryHandler<TResult>(IQuery<TResult> query)
		{
			var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			var handler = (IQueryHandler<IQuery<TResult>, TResult>)_container.GetInstance(handlerType);
			return handler;
		}
	}
}

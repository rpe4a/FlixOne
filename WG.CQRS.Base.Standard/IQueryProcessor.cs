using System.Threading.Tasks;

namespace CQRS.Base.Standard
{
	public interface IQueryProcessor
	{
		Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
		TResult Process<TResult>(IQuery<TResult> query);
	}
}

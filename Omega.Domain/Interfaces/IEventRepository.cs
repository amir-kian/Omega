namespace Omega.Domain.Interfaces
{
	public interface IEventRepository<T> where T : IDomainEvent
	{
		Task AddEvent(T @event);
		Task<IEnumerable<T>> GetEvents();
	}
}

using Omega.Domain.Interfaces;

namespace Omega.Domain.Events.Request
{
	public class RequestDeletedEvent : IDomainEvent
	{
		public RequestDeletedEvent(int id)
		{
			Id = id;
		}

		public int Id { get; }
	}
}

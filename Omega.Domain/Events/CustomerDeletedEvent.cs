using Omega.Domain.Interfaces;

namespace Omega.Domain.Events
{
	public class CustomerDeletedEvent : IDomainEvent
	{
		public CustomerDeletedEvent(int id)
		{
			Id = id;
		}

		public int Id { get; }
	}
}

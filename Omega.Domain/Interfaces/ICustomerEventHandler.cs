using Omega.Domain.Events;

namespace Omega.Domain.Interfaces
{
	public interface ICustomerEventHandler
	{
		Task Handle(CustomerCreatedEvent @event);
		Task Handle(CustomerUpdatedEvent @event);
		Task Handle(CustomerDeletedEvent @event);
	}
}

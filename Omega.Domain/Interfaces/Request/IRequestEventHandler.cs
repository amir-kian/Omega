using Omega.Domain.Events.Request;

namespace Omega.Domain.Interfaces.Request
{
	public interface IRequestEventHandler
	{
		Task Handle(RequestCreatedEvent @event);
		Task Handle(RequestUpdatedEvent @event);
		Task Handle(RequestDeletedEvent @event);
	}
}

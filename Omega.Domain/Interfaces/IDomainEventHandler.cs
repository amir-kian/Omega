namespace Omega.Domain.Interfaces
{
	public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
	{
		void Handle(TEvent @event);
	}
}

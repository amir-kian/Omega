
using Omega.Domain.Interfaces;

namespace Omega.Domain.Events.Request
{
	public class RequestUpdatedEvent : IDomainEvent
	{

		public int Id { get; set; }
		public string Title { get; set; }
		public int RequestType { get; set; }
		public double Fund { get; set; }

		public RequestUpdatedEvent(int id, string title, int requestType, double fund)
		{
			Id = id;
			Title = title;
			RequestType = requestType;
			Fund = fund;
		}




	}


}

using MediatR;

namespace Omega.Domain.Commands.Request
{
	public class CreateRequestCommand : IRequest<Entities.Request>
	{
		public string Title { get; set; }
		public int RequestType { get; set; }
		public double Fund { get; set; }

		public CreateRequestCommand(string title, int requestType, double fund)
		{
			Title = title;
			RequestType = requestType;
			Fund = fund;

		}
	}
}

using MediatR;

namespace Omega.Domain.Commands.Request
{
	public class DeleteRequestCommand : IRequest<Unit>
	{
		public int Id { get; set; }

		public DeleteRequestCommand(int id)
		{
			Id = id;
		}
	}
}
using MediatR;

namespace Omega.Domain.Commands
{
	public class DeleteCustomerCommand : IRequest<Unit>
	{
		public int Id { get; set; }

		public DeleteCustomerCommand(int id)
		{
			Id = id;
		}
	}
}
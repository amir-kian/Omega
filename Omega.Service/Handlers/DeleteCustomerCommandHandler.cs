using MediatR;
using Omega.Domain.Commands;
using Omega.Domain.Events;
using Omega.Domain.Interfaces;


namespace Omega.Service.Handlers
{
	public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
	{
		private readonly IWriteCustomerRepository _repository;
		private readonly ICustomerEventHandler _customerEventHandler;

		public DeleteCustomerCommandHandler(IWriteCustomerRepository repository, ICustomerEventHandler customerEventHandler)
		{
			_repository = repository;
			_customerEventHandler = customerEventHandler;
		}

		public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = await _repository.GetById(request.Id);

			if (customer == null)
			{
				throw new ArgumentException($"Customer with ID {request.Id} does not exist.");
			}

			await _repository.Delete(customer);

			var deletedEvent = new CustomerDeletedEvent(customer.Id);
			await _customerEventHandler.Handle(deletedEvent);

			return Unit.Value;
		}
	}
}
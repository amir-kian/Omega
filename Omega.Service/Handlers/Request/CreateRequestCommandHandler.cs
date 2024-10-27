
using MediatR;
using Omega.Domain.Commands.Request;
using Omega.Domain.Events.Request;
using Omega.Domain.Interfaces.Request;
using PhoneNumbers;

namespace Omega.Service.Handlers.Request
{
	public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Domain.Entities.Request>
	{
		private readonly IWriteRequestRepository _repository;
		private readonly IRequestEventHandler _requestEventHandler;

		public CreateRequestCommandHandler(IWriteRequestRepository repository, IRequestEventHandler requestEventHandler)
		{
			_repository = repository;
			_requestEventHandler = requestEventHandler;
		}

		public async Task<Domain.Entities.Request> Handle(CreateRequestCommand req, CancellationToken cancellationToken)
		{

			var request = new Domain.Entities.Request(req.Title, (Domain.Enums.RequestType)req.RequestType, req.Fund);

			await _repository.Add(request);

			var createdEvent = new RequestCreatedEvent(
				request.Id,
				request.Title,
			   (int)request.RequestType,
				request.Fund
			);
			await _requestEventHandler.Handle(createdEvent);

			return request;
		}
	}
}

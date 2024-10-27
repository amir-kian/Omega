using MediatR;

namespace Omega.Domain.Commands.Request;

public class UpdateRequestCommand : IRequest<Unit>
{
	public int Id { get; }
	public string Title { get; set; }
	public int RequestType { get; set; }
	public int Fund { get; set; }



	public UpdateRequestCommand(int id, string title, int requestType, double Fund)
	{
		Id = id;
		Title = title;
		RequestType = requestType;
		Fund = Fund;

	}

}
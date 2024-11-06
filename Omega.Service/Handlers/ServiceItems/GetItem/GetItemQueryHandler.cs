using MediatR;
using Omega.Core.DTOs.ServiceItems.GetItem;
using Omega.Domain.Queries.ServiceItems.GetItem;
using Omega.ExternalService.EbeheshtServices.Contracts;

namespace Omega.UseCases.Handlers.ServiceItems.GetItem;


public class GetItemQueryHandler : IRequestHandler<GetServiceItemQuery, GetServiceItemReadDTO>
{
	private readonly IEbeheshtService _ebeheshtService;

	public GetItemQueryHandler(IEbeheshtService ebeheshtService)
	{
		_ebeheshtService = ebeheshtService;
	}

	public async Task<GetServiceItemReadDTO> Handle(GetServiceItemQuery request, CancellationToken cancellationToken)
	{
		var serviceItemsResponse = await _ebeheshtService.GetItemAsync(request.ServiceReqiestId);
		var serviceItem = serviceItemsResponse.Data;

		var result = new GetServiceItemReadDTO(
			serviceItem.Id,
			serviceItem.DefaultImageIndex,
			serviceItem.Images,
			serviceItem.ServiceId,
			serviceItem.Name,
			serviceItem.Code,
			serviceItem.Price,
			serviceItem.IsDefault,
			serviceItem.TransportCostIncluded,
			serviceItem.Qty,
			serviceItem.MinQty,
			serviceItem.MaxQty,
			serviceItem.Description,
			serviceItem.ContractorSharePercent,
			serviceItem.UnitMeasureId,
			serviceItem.UnitMeasureName,
			serviceItem.SuperContractorsId
			);
		

		return result;
	}
}

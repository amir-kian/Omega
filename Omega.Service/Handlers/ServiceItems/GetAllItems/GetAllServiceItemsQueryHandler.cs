using MediatR;
using Omega.Core.DTOs.ServiceItems.GetAllItems;
using Omega.Domain.Queries.ServiceItems.GetAllItems;
using Omega.ExternalService.EbeheshtServices.Contracts;

namespace Omega.UseCases.Handlers.ServiceItems.GetAllItems;


public class GetAllServiceItemsQueryHandler : IRequestHandler<GetAllServiceItemsQuery, ServiceItemReadDTO[]>
{
    private readonly IEbeheshtService _ebeheshtService;

    public GetAllServiceItemsQueryHandler(IEbeheshtService ebeheshtService)
    {
        _ebeheshtService = ebeheshtService;
    }

    public async Task<ServiceItemReadDTO[]> Handle(GetAllServiceItemsQuery request, CancellationToken cancellationToken)
    {
        var serviceItemsResponse = await _ebeheshtService.GetAllItemsAsync();
        var serviceItems = serviceItemsResponse.Data;

        var result = serviceItems.Select(item => new ServiceItemReadDTO(
            item.Id,
            item.ServiceId,
            item.Name,
            item.Code,
            item.Price,
            item.IsDefault,
            item.TransportCostIncluded,
            item.Qty,
            item.MinQty,
            item.MaxQty,
            item.Description,
            item.ContractorSharePercent,
            item.UnitMeasureId,
            item.UnitMeasureName,
            item.SuperContractorsId
        )).ToArray();

        return result;

    }
}


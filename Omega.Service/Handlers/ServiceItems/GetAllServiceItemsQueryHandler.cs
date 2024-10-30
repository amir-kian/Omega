using MediatR;
using Omega.Core.DTOs;
using Omega.Core.DTOs.ServiceItems;
using Omega.Domain.Interfaces;
using Omega.Domain.Queries;
using Omega.Domain.Queries.ServiceItems;
using Omega.ExternalService.EbeheshtServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Service.Handlers.ServiceItems;


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

		var result = serviceItems.Select(item => new ServiceItemReadDTO
		{
			Id = item.Id,
			ServiceId = item.ServiceId,
			Name = item.Name,
			Code = item.Code,
			Price = item.Price,
			IsDefault = item.IsDefault,
			TransportCostIncluded = item.TransportCostIncluded,
			Qty = item.Qty,
			MinQty = item.MinQty,
			MaxQty = item.MaxQty,
			Description = item.Description,
			ContractorSharePercent = item.ContractorSharePercent,
			UnitMeasureId = item.UnitMeasureId,
			UnitMeasureName = item.UnitMeasureName,
			SuperContractorsId = item.SuperContractorsId
		}).ToArray();

		return result;
	}
}


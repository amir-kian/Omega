namespace Omega.Core.DTOs.ServiceItems.GetItem;

public record GetServiceItemReadDTO(
	string Id,
	int DefaultImageIndex,
	List<string> Images,
	int ServiceId,
	string Name,
	string Code,
	decimal Price,
	bool IsDefault,
	bool TransportCostIncluded,
	int Qty,
	int MinQty,
	int MaxQty,
	string Description,
	double ContractorSharePercent,
	int UnitMeasureId,
	string UnitMeasureName,
	List<int> SuperContractorsId
	);

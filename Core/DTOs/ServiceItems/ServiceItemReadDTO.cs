namespace Omega.Core.DTOs.ServiceItems;


	public record ServiceItemReadDTO(
		int Id,
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
		decimal ContractorSharePercent,
		int UnitMeasureId,
		string UnitMeasureName,
		int? SuperContractorsId);

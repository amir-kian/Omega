using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Omega.ExternalService.EbeheshtServices.Models.GetItem;


public class GetItemResponse
{
	public string Id { get; set; }
	public ItemData Data { get; set; }
	public bool Success { get; set; }
	public string Description { get; set; }
	public int Total { get; set; }
}

public class ItemData
{
	public string Id { get; set; }
	public int DefaultImageIndex { get; set; }
	public List<string> Images { get; set; }
	public int ServiceId { get; set; }
	public string Name { get; set; }
	public string Code { get; set; }
	public decimal Price { get; set; }
	public bool IsDefault { get; set; }
	public bool TransportCostIncluded { get; set; }
	public int Qty { get; set; }
	public int MinQty { get; set; }
	public int MaxQty { get; set; }
	public string Description { get; set; }
	public double ContractorSharePercent { get; set; }
	public int UnitMeasureId { get; set; }
	public string UnitMeasureName { get; set; }
	public List<int> SuperContractorsId { get; set; }
}

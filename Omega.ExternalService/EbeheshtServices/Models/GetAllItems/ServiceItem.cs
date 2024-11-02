using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.ExternalService.EbeheshtServices.Models;

public class ServiceItem
{
    public int Id { get; set; }
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
    public decimal ContractorSharePercent { get; set; }
    public int UnitMeasureId { get; set; }
    public string UnitMeasureName { get; set; }
    public int? SuperContractorsId { get; set; }
}

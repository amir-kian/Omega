using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.ExternalService.EbeheshtServices.Models;

public class ServiceResponse
{
    public int Id { get; set; }
    public List<ServiceItem> Data { get; set; }
    public bool Success { get; set; }
    public string Description { get; set; }
    public decimal Total { get; set; }
}

using Omega.ExternalService.EbeheshtServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.ExternalService.EbeheshtServices.Contracts;

public interface IEbeheshtService
{
	Task<ServiceResponse> GetAllItemsAsync();
}

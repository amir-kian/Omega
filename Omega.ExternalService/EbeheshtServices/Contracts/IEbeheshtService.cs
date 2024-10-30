using Omega.ExternalService.EbeheshtServices.Models;

namespace Omega.ExternalService.EbeheshtServices.Contracts;

public interface IEbeheshtService
{
	Task<ServiceResponse> GetAllItemsAsync();
}

using Omega.ExternalService.EbeheshtServices.Models;
using Omega.ExternalService.EbeheshtServices.Models.GetItem;

namespace Omega.ExternalService.EbeheshtServices.Contracts;

public interface IEbeheshtService
{
	Task<ServiceResponse> GetAllItemsAsync();
	Task<GetItemResponse> GetItemAsync(int itemId);
}

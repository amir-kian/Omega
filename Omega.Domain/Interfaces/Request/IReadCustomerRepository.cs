
namespace Omega.Domain.Interfaces.Request
{
	public interface IReadRequestRepository
	{
		Task<Entities.Request> GetById(int id);
		Task<List<Entities.Request>> GetAll();
		Task<List<Entities.Request>> GetAllRequests();
	}
}

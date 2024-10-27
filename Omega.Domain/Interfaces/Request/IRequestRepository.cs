
namespace Omega.Domain.Interfaces.Request
{
	public interface IRequestRepository
	{
		void Add(Entities.Request Request);
		Entities.Request GetById(int RequestId);
		void Update(Entities.Request Request);
		void Delete(Entities.Request Request);
		IEnumerable<Entities.Request> GetAllRequests();

	}
}

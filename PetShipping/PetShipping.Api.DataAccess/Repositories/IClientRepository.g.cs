using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientRepository
	{
		Task<Client> Create(Client item);

		Task Update(Client item);

		Task Delete(int id);

		Task<Client> Get(int id);

		Task<List<Client>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ClientCommunication>> ClientCommunications(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<Pet>> Pets(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<Sale>> Sales(int clientId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e5c20c50d15aca61fa5b4a11203039fa</Hash>
</Codenesium>*/
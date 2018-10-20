using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IClientRepository
	{
		Task<Client> Create(Client item);

		Task Update(Client item);

		Task Delete(int id);

		Task<Client> Get(int id);

		Task<List<Client>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ClientCommunication>> ClientCommunicationsByClientId(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<Pet>> PetsByClientId(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<Sale>> SalesByClientId(int clientId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>36b07b5f3b73367312b979bf661b69b8</Hash>
</Codenesium>*/
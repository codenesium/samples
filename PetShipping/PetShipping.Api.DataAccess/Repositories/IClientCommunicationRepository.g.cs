using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientCommunicationRepository
	{
		Task<ClientCommunication> Create(ClientCommunication item);

		Task Update(ClientCommunication item);

		Task Delete(int id);

		Task<ClientCommunication> Get(int id);

		Task<List<ClientCommunication>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>47e762c7c947507e14bad5b69046265a</Hash>
</Codenesium>*/
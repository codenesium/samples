using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientCommunicationRepository
	{
		Task<POCOClientCommunication> Create(ApiClientCommunicationModel model);

		Task Update(int id,
		            ApiClientCommunicationModel model);

		Task Delete(int id);

		Task<POCOClientCommunication> Get(int id);

		Task<List<POCOClientCommunication>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4e2a7b1227caf353303296c96685ce3f</Hash>
</Codenesium>*/
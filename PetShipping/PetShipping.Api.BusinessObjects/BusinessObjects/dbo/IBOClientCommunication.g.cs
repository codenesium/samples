using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOClientCommunication
	{
		Task<CreateResponse<POCOClientCommunication>> Create(
			ApiClientCommunicationModel model);

		Task<ActionResponse> Update(int id,
		                            ApiClientCommunicationModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOClientCommunication> Get(int id);

		Task<List<POCOClientCommunication>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3837804e2d961a402bc934266b415068</Hash>
</Codenesium>*/
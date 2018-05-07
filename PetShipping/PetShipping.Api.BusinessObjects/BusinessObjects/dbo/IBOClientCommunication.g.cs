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
		Task<CreateResponse<int>> Create(
			ClientCommunicationModel model);

		Task<ActionResponse> Update(int id,
		                            ClientCommunicationModel model);

		Task<ActionResponse> Delete(int id);

		POCOClientCommunication Get(int id);

		List<POCOClientCommunication> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7b7b95b53640955e181ebbfb10911e7e</Hash>
</Codenesium>*/
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

		POCOClientCommunication Get(int id);

		List<POCOClientCommunication> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>46c51579e26b12adbba160c08bfb9840</Hash>
</Codenesium>*/
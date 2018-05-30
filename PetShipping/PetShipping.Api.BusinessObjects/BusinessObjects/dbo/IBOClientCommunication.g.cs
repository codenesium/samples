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
		Task<CreateResponse<ApiClientCommunicationResponseModel>> Create(
			ApiClientCommunicationRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiClientCommunicationRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClientCommunicationResponseModel> Get(int id);

		Task<List<ApiClientCommunicationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c1890da432b81f36897f3f122cd60278</Hash>
</Codenesium>*/
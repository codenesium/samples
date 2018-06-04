using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IClientCommunicationService
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
    <Hash>e8b5488d809f00fa0d808aec43058da2</Hash>
</Codenesium>*/
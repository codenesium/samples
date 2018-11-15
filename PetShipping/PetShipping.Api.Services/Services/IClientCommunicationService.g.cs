using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IClientCommunicationService
	{
		Task<CreateResponse<ApiClientCommunicationServerResponseModel>> Create(
			ApiClientCommunicationServerRequestModel model);

		Task<UpdateResponse<ApiClientCommunicationServerResponseModel>> Update(int id,
		                                                                        ApiClientCommunicationServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClientCommunicationServerResponseModel> Get(int id);

		Task<List<ApiClientCommunicationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>01462b4cef3e2267a8c17e0e090cd9ad</Hash>
</Codenesium>*/
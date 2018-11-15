using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IClientService
	{
		Task<CreateResponse<ApiClientServerResponseModel>> Create(
			ApiClientServerRequestModel model);

		Task<UpdateResponse<ApiClientServerResponseModel>> Update(int id,
		                                                           ApiClientServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClientServerResponseModel> Get(int id);

		Task<List<ApiClientServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiClientCommunicationServerResponseModel>> ClientCommunicationsByClientId(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetServerResponseModel>> PetsByClientId(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleServerResponseModel>> SalesByClientId(int clientId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a5a9159177e506e564c767ec958d94ac</Hash>
</Codenesium>*/
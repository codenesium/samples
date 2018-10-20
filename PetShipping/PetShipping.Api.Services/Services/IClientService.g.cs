using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IClientService
	{
		Task<CreateResponse<ApiClientResponseModel>> Create(
			ApiClientRequestModel model);

		Task<UpdateResponse<ApiClientResponseModel>> Update(int id,
		                                                     ApiClientRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClientResponseModel> Get(int id);

		Task<List<ApiClientResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiClientCommunicationResponseModel>> ClientCommunicationsByClientId(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetResponseModel>> PetsByClientId(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleResponseModel>> SalesByClientId(int clientId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b65d714297f9e01fa9d143b77ee249a5</Hash>
</Codenesium>*/
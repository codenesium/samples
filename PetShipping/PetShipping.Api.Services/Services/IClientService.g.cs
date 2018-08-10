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

		Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetResponseModel>> Pets(int clientId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleResponseModel>> Sales(int clientId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>375010174db4387e884caf4b743205f7</Hash>
</Codenesium>*/
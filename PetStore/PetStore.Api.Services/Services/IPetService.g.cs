using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IPetService
	{
		Task<CreateResponse<ApiPetServerResponseModel>> Create(
			ApiPetServerRequestModel model);

		Task<UpdateResponse<ApiPetServerResponseModel>> Update(int id,
		                                                        ApiPetServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPetServerResponseModel> Get(int id);

		Task<List<ApiPetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleServerResponseModel>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b4d8ade3de542e5720c941a3f8d3ef97</Hash>
</Codenesium>*/
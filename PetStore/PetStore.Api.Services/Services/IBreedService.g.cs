using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IBreedService
	{
		Task<CreateResponse<ApiBreedServerResponseModel>> Create(
			ApiBreedServerRequestModel model);

		Task<UpdateResponse<ApiBreedServerResponseModel>> Update(int id,
		                                                          ApiBreedServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBreedServerResponseModel> Get(int id);

		Task<List<ApiBreedServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetServerResponseModel>> PetsByBreedId(int breedId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>694d86790aedd9dec5b94d5588d5ade7</Hash>
</Codenesium>*/
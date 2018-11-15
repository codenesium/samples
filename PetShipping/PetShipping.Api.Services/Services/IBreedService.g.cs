using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
    <Hash>b57fd8b97abc26e3e14eaa8a0473aee4</Hash>
</Codenesium>*/
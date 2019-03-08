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

		Task<List<ApiBreedServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiBreedServerResponseModel>> BySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bd9c9463fbb906424d25ddc8c365bbc1</Hash>
</Codenesium>*/
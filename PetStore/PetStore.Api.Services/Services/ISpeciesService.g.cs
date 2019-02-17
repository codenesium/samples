using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface ISpeciesService
	{
		Task<CreateResponse<ApiSpeciesServerResponseModel>> Create(
			ApiSpeciesServerRequestModel model);

		Task<UpdateResponse<ApiSpeciesServerResponseModel>> Update(int id,
		                                                            ApiSpeciesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpeciesServerResponseModel> Get(int id);

		Task<List<ApiSpeciesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiBreedServerResponseModel>> BreedsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>24ea8be09793bd257880f9362788f0b7</Hash>
</Codenesium>*/
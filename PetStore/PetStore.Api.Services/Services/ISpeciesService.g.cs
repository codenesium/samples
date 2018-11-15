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

		Task<List<ApiSpeciesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetServerResponseModel>> PetsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0e796a84bae9580a9daab0e6adc30cfe</Hash>
</Codenesium>*/
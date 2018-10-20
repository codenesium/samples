using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface ISpeciesService
	{
		Task<CreateResponse<ApiSpeciesResponseModel>> Create(
			ApiSpeciesRequestModel model);

		Task<UpdateResponse<ApiSpeciesResponseModel>> Update(int id,
		                                                      ApiSpeciesRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpeciesResponseModel> Get(int id);

		Task<List<ApiSpeciesResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetResponseModel>> PetsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>492b6a65314fdfafe5aec45a9dd9f96d</Hash>
</Codenesium>*/
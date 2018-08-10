using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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

		Task<List<ApiBreedResponseModel>> Breeds(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5254a8895aa55e676790dc2b89d46602</Hash>
</Codenesium>*/
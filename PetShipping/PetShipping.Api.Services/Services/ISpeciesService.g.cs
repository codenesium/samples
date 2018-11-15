using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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

		Task<List<ApiBreedServerResponseModel>> BreedsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1e56dd6de30d60046c0faa424012681a</Hash>
</Codenesium>*/
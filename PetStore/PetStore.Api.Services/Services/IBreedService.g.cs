using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IBreedService
	{
		Task<CreateResponse<ApiBreedResponseModel>> Create(
			ApiBreedRequestModel model);

		Task<UpdateResponse<ApiBreedResponseModel>> Update(int id,
		                                                    ApiBreedRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBreedResponseModel> Get(int id);

		Task<List<ApiBreedResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetResponseModel>> PetsByBreedId(int breedId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dad1aac221496e0e8b9689586d33affd</Hash>
</Codenesium>*/
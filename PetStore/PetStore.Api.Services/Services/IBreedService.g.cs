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

		Task<List<ApiPetResponseModel>> Pets(int breedId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>737f477279e31dc1c2627cbee85e7ad8</Hash>
</Codenesium>*/
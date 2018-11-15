using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IPenService
	{
		Task<CreateResponse<ApiPenServerResponseModel>> Create(
			ApiPenServerRequestModel model);

		Task<UpdateResponse<ApiPenServerResponseModel>> Update(int id,
		                                                        ApiPenServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPenServerResponseModel> Get(int id);

		Task<List<ApiPenServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPetServerResponseModel>> PetsByPenId(int penId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>95060d5739802e9c1a0afb9c9a4acac4</Hash>
</Codenesium>*/
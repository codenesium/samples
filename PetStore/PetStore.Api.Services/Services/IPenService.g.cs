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

		Task<List<ApiPenServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPetServerResponseModel>> PetsByPenId(int penId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d09fa46bd7ef1979ed136cc73e04a6d5</Hash>
</Codenesium>*/
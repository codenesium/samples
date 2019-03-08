using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IPetService
	{
		Task<CreateResponse<ApiPetServerResponseModel>> Create(
			ApiPetServerRequestModel model);

		Task<UpdateResponse<ApiPetServerResponseModel>> Update(int id,
		                                                        ApiPetServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPetServerResponseModel> Get(int id);

		Task<List<ApiPetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>56d4a796149bd7ed4e2c18695f5fd300</Hash>
</Codenesium>*/
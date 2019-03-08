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
	}
}

/*<Codenesium>
    <Hash>3c040b196ac2c3c71edd3532ff94e61d</Hash>
</Codenesium>*/
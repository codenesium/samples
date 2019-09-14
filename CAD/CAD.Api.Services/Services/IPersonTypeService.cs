using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IPersonTypeService
	{
		Task<CreateResponse<ApiPersonTypeServerResponseModel>> Create(
			ApiPersonTypeServerRequestModel model);

		Task<UpdateResponse<ApiPersonTypeServerResponseModel>> Update(int id,
		                                                               ApiPersonTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPersonTypeServerResponseModel> Get(int id);

		Task<List<ApiPersonTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallPersonServerResponseModel>> CallPersonsByPersonTypeId(int personTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>cc5825f54d839f77d7520d3a541ba83f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
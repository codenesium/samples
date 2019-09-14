using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IPersonService
	{
		Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model);

		Task<UpdateResponse<ApiPersonServerResponseModel>> Update(int id,
		                                                           ApiPersonServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPersonServerResponseModel> Get(int id);

		Task<List<ApiPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallPersonServerResponseModel>> CallPersonsByPersonId(int personId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8679e8aa28b45bfcea977fb4921b2008</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
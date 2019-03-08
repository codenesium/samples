using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostTypesService
	{
		Task<CreateResponse<ApiPostTypesServerResponseModel>> Create(
			ApiPostTypesServerRequestModel model);

		Task<UpdateResponse<ApiPostTypesServerResponseModel>> Update(int id,
		                                                              ApiPostTypesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostTypesServerResponseModel> Get(int id);

		Task<List<ApiPostTypesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostsServerResponseModel>> PostsByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a1fb3f5d99654caf337acddf17cf860d</Hash>
</Codenesium>*/
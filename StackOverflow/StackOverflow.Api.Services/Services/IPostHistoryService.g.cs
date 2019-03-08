using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostHistoryService
	{
		Task<CreateResponse<ApiPostHistoryServerResponseModel>> Create(
			ApiPostHistoryServerRequestModel model);

		Task<UpdateResponse<ApiPostHistoryServerResponseModel>> Update(int id,
		                                                                ApiPostHistoryServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostHistoryServerResponseModel> Get(int id);

		Task<List<ApiPostHistoryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostHistoryServerResponseModel>> ByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostHistoryServerResponseModel>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostHistoryServerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ab1ca20dddc2ec70a9196b09dd561267</Hash>
</Codenesium>*/
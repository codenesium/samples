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
	}
}

/*<Codenesium>
    <Hash>1be3150ae735ec278ee6a6bef0406272</Hash>
</Codenesium>*/
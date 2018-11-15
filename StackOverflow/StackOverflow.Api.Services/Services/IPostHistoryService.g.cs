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

		Task<List<ApiPostHistoryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fe63ecf5ebb3cbefa7791802c4f2513b</Hash>
</Codenesium>*/
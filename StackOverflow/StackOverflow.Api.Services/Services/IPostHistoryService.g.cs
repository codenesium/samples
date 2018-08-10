using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostHistoryService
	{
		Task<CreateResponse<ApiPostHistoryResponseModel>> Create(
			ApiPostHistoryRequestModel model);

		Task<UpdateResponse<ApiPostHistoryResponseModel>> Update(int id,
		                                                          ApiPostHistoryRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostHistoryResponseModel> Get(int id);

		Task<List<ApiPostHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d51f46eb8c9d1b18e2ffbcfb6e9f7996</Hash>
</Codenesium>*/
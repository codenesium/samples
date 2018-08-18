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
    <Hash>223beba05ccb7e4529998733ca97f76a</Hash>
</Codenesium>*/
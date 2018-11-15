using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IRetweetService
	{
		Task<CreateResponse<ApiRetweetServerResponseModel>> Create(
			ApiRetweetServerRequestModel model);

		Task<UpdateResponse<ApiRetweetServerResponseModel>> Update(int id,
		                                                            ApiRetweetServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRetweetServerResponseModel> Get(int id);

		Task<List<ApiRetweetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetServerResponseModel>> ByRetwitterUserId(int? retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetServerResponseModel>> ByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>aadbcd25a34155d9687a7548de2a5c92</Hash>
</Codenesium>*/
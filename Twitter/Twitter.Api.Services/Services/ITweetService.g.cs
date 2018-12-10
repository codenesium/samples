using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface ITweetService
	{
		Task<CreateResponse<ApiTweetServerResponseModel>> Create(
			ApiTweetServerRequestModel model);

		Task<UpdateResponse<ApiTweetServerResponseModel>> Update(int tweetId,
		                                                          ApiTweetServerRequestModel model);

		Task<ActionResponse> Delete(int tweetId);

		Task<ApiTweetServerResponseModel> Get(int tweetId);

		Task<List<ApiTweetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetServerResponseModel>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetServerResponseModel>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetServerResponseModel>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetServerResponseModel>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ce390f53a04e1fa0b8123c5e00ae3340</Hash>
</Codenesium>*/
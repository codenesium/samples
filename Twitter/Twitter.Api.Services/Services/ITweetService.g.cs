using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface ITweetService
	{
		Task<CreateResponse<ApiTweetResponseModel>> Create(
			ApiTweetRequestModel model);

		Task<UpdateResponse<ApiTweetResponseModel>> Update(int tweetId,
		                                                    ApiTweetRequestModel model);

		Task<ActionResponse> Delete(int tweetId);

		Task<ApiTweetResponseModel> Get(int tweetId);

		Task<List<ApiTweetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetResponseModel>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetResponseModel>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetResponseModel>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetResponseModel>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8dd2ecda52a8df27cc19db82baf224c0</Hash>
</Codenesium>*/
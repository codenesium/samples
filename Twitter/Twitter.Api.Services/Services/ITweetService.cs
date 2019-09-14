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

		Task<List<ApiTweetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTweetServerResponseModel>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetServerResponseModel>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetServerResponseModel>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetServerResponseModel>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetServerResponseModel>> ByLikerUserId(int tweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1d1511f0bc6431b5e4980990743e3067</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
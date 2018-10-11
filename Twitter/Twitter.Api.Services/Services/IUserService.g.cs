using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserResponseModel>> Create(
			ApiUserRequestModel model);

		Task<UpdateResponse<ApiUserResponseModel>> Update(int userId,
		                                                   ApiUserRequestModel model);

		Task<ActionResponse> Delete(int userId);

		Task<ApiUserResponseModel> Get(int userId);

		Task<List<ApiUserResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserResponseModel>> ByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDirectTweetResponseModel>> DirectTweets(int taggedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFollowerResponseModel>> Followers(int followedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessageResponseModel>> Messages(int senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerResponseModel>> Messengers(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetResponseModel>> QuoteTweets(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiReplyResponseModel>> Replies(int replierUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetResponseModel>> Retweets(int retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetResponseModel>> Tweets(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserResponseModel>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>cec466ccff769f2e04efab0205b612d7</Hash>
</Codenesium>*/
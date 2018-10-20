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

		Task<List<ApiDirectTweetResponseModel>> DirectTweetsByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFollowerResponseModel>> FollowersByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFollowerResponseModel>> FollowersByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessageResponseModel>> MessagesBySenderUserId(int senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerResponseModel>> MessengersByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerResponseModel>> MessengersByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetResponseModel>> QuoteTweetsByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiReplyResponseModel>> RepliesByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetResponseModel>> RetweetsByRetwitterUserId(int retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetResponseModel>> TweetsByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserResponseModel>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7d21b3fd701d82a4fca866b40fe950ee</Hash>
</Codenesium>*/
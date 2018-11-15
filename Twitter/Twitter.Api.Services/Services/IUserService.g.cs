using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model);

		Task<UpdateResponse<ApiUserServerResponseModel>> Update(int userId,
		                                                         ApiUserServerRequestModel model);

		Task<ActionResponse> Delete(int userId);

		Task<ApiUserServerResponseModel> Get(int userId);

		Task<List<ApiUserServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserServerResponseModel>> ByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDirectTweetServerResponseModel>> DirectTweetsByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFollowerServerResponseModel>> FollowersByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFollowerServerResponseModel>> FollowersByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessageServerResponseModel>> MessagesBySenderUserId(int senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> MessengersByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> MessengersByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetServerResponseModel>> QuoteTweetsByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiReplyServerResponseModel>> RepliesByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetServerResponseModel>> RetweetsByRetwitterUserId(int retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetServerResponseModel>> TweetsByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserServerResponseModel>> ByLocationId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserServerResponseModel>> BySourceTweetId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>07afbaf890728f7dd23de00f6ad16f9c</Hash>
</Codenesium>*/
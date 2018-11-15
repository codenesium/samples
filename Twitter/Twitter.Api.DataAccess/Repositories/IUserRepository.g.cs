using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IUserRepository
	{
		Task<User> Create(User item);

		Task Update(User item);

		Task Delete(int userId);

		Task<User> Get(int userId);

		Task<List<User>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<User>> ByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0);

		Task<List<DirectTweet>> DirectTweetsByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Follower>> FollowersByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Follower>> FollowersByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Message>> MessagesBySenderUserId(int senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> MessengersByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> MessengersByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<QuoteTweet>> QuoteTweetsByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Reply>> RepliesByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> RetweetsByRetwitterUserId(int retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tweet>> TweetsByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<Location> LocationByLocationLocationId(int locationLocationId);

		Task<List<User>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<Tweet> CreateTweet(Tweet item);

		Task DeleteTweet(Tweet item);

		Task<List<User>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<QuoteTweet> CreateQuoteTweet(QuoteTweet item);

		Task DeleteQuoteTweet(QuoteTweet item);
	}
}

/*<Codenesium>
    <Hash>7f6d75e9f4a175678a3dd6eadea2b14c</Hash>
</Codenesium>*/
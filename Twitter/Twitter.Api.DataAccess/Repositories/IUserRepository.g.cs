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
	}
}

/*<Codenesium>
    <Hash>d02026354a460f17fa4eaac4786b8e2c</Hash>
</Codenesium>*/
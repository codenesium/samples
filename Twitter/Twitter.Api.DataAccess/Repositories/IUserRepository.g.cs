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

		Task<List<User>> All(int limit = int.MaxValue, int offset = 0, string query = "");

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

		Task<List<User>> ByTweetId(int tweetId, int limit = int.MaxValue, int offset = 0);

		Task<Like> CreateLike(Like item);

		Task DeleteLike(Like item);
	}
}

/*<Codenesium>
    <Hash>33227fac952667a9b30c94b3f0415654</Hash>
</Codenesium>*/
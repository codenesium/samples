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

		Task<List<DirectTweet>> DirectTweets(int taggedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Follower>> Followers(int followedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Message>> Messages(int senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> Messengers(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<QuoteTweet>> QuoteTweets(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Reply>> Replies(int replierUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> Retweets(int retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tweet>> Tweets(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<Location> LocationByLocationLocationId(int locationLocationId);

		Task<List<User>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d9b90137d11ca4651f62abf0abb90880</Hash>
</Codenesium>*/
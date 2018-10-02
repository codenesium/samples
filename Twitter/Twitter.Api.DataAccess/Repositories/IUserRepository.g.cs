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

		Task<List<Like>> Likes(int likerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Message>> Messages(int senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> Messengers(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<QuoteTweet>> QuoteTweets(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Reply>> Replies(int replierUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> Retweets(int retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tweet>> Tweets(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<Location> GetLocation(int locationLocationId);
	}
}

/*<Codenesium>
    <Hash>6897503f20b64813112c9623ab4829b5</Hash>
</Codenesium>*/
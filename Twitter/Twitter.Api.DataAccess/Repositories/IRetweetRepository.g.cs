using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IRetweetRepository
	{
		Task<Retweet> Create(Retweet item);

		Task Update(Retweet item);

		Task Delete(int id);

		Task<Retweet> Get(int id);

		Task<List<Retweet>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> ByRetwitterUserId(int? retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> ByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByRetwitterUserId(int? retwitterUserId);

		Task<Tweet> TweetByTweetTweetId(int tweetTweetId);
	}
}

/*<Codenesium>
    <Hash>77e090075a781ce79337ca39e31637da</Hash>
</Codenesium>*/
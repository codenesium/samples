using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface ITweetRepository
	{
		Task<Tweet> Create(Tweet item);

		Task Update(Tweet item);

		Task Delete(int tweetId);

		Task<Tweet> Get(int tweetId);

		Task<List<Tweet>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Tweet>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tweet>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Like>> Likes(int tweetId, int limit = int.MaxValue, int offset = 0);

		Task<List<QuoteTweet>> QuoteTweets(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> Retweets(int tweetTweetId, int limit = int.MaxValue, int offset = 0);

		Task<Location> GetLocation(int locationId);

		Task<User> GetUser(int userUserId);
	}
}

/*<Codenesium>
    <Hash>1924119a38dc0e0da5e27c7ec856a93d</Hash>
</Codenesium>*/
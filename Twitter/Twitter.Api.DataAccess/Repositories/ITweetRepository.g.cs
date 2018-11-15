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

		Task<List<QuoteTweet>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);

		Task<Location> LocationByLocationId(int locationId);

		Task<User> UserByUserUserId(int userUserId);

		Task<List<Tweet>> ByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<QuoteTweet> CreateQuoteTweet(QuoteTweet item);

		Task DeleteQuoteTweet(QuoteTweet item);
	}
}

/*<Codenesium>
    <Hash>3eecd523f1d681bc1b23ad8ed86d50a7</Hash>
</Codenesium>*/
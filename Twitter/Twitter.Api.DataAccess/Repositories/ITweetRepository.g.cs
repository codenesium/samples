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

		Task<List<Tweet>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Tweet>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tweet>> ByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<QuoteTweet>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);

		Task<Location> LocationByLocationId(int locationId);

		Task<User> UserByUserUserId(int userUserId);

		Task<List<Tweet>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0);

		Task<Like> CreateLike(Like item);

		Task DeleteLike(Like item);
	}
}

/*<Codenesium>
    <Hash>a702265148512dcc0087b4793d5ee78b</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IQuoteTweetRepository
	{
		Task<QuoteTweet> Create(QuoteTweet item);

		Task Update(QuoteTweet item);

		Task Delete(int quoteTweetId);

		Task<QuoteTweet> Get(int quoteTweetId);

		Task<List<QuoteTweet>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<QuoteTweet>> ByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<QuoteTweet>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<User> GetUser(int retweeterUserId);

		Task<Tweet> GetTweet(int sourceTweetId);
	}
}

/*<Codenesium>
    <Hash>69b998648f5f0d8f8309342f5ea3362a</Hash>
</Codenesium>*/
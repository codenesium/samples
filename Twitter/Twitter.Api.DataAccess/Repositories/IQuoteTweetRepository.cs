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

		Task<List<QuoteTweet>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<QuoteTweet>> ByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<QuoteTweet>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByRetweeterUserId(int retweeterUserId);

		Task<Tweet> TweetBySourceTweetId(int sourceTweetId);
	}
}

/*<Codenesium>
    <Hash>d7a9fb37692b771d6605bb4f3f1110e2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
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

		Task<User> GetUser(int? retwitterUserId);

		Task<Tweet> GetTweet(int tweetTweetId);
	}
}

/*<Codenesium>
    <Hash>0561a9a3cacef82a621eb82b872f8462</Hash>
</Codenesium>*/
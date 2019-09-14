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

		Task<List<Retweet>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Retweet>> ByRetwitterUserId(int? retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Retweet>> ByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByRetwitterUserId(int? retwitterUserId);

		Task<Tweet> TweetByTweetTweetId(int tweetTweetId);
	}
}

/*<Codenesium>
    <Hash>624941e54e2b632f28f161e16094e9ed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
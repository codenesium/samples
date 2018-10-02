using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IDirectTweetRepository
	{
		Task<DirectTweet> Create(DirectTweet item);

		Task Update(DirectTweet item);

		Task Delete(int tweetId);

		Task<DirectTweet> Get(int tweetId);

		Task<List<DirectTweet>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<DirectTweet>> ByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0);

		Task<User> GetUser(int taggedUserId);
	}
}

/*<Codenesium>
    <Hash>0aa1db840951bb6a1fd95f4200c1e189</Hash>
</Codenesium>*/
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

		Task<User> UserByTaggedUserId(int taggedUserId);
	}
}

/*<Codenesium>
    <Hash>3293f8bd1ed7ed42d42106b30f1e0ed9</Hash>
</Codenesium>*/
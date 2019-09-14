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

		Task<List<DirectTweet>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<DirectTweet>> ByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByTaggedUserId(int taggedUserId);
	}
}

/*<Codenesium>
    <Hash>cb877cb4ef7690437ee218d4b57ea98d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
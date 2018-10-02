using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface ILikeRepository
	{
		Task<Like> Create(Like item);

		Task Update(Like item);

		Task Delete(int likeId);

		Task<Like> Get(int likeId);

		Task<List<Like>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Like>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Like>> ByTweetId(int tweetId, int limit = int.MaxValue, int offset = 0);

		Task<User> GetUser(int likerUserId);

		Task<Tweet> GetTweet(int tweetId);
	}
}

/*<Codenesium>
    <Hash>1dc50178ff837766357a731db3717c30</Hash>
</Codenesium>*/
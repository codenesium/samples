using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IFollowerRepository
	{
		Task<Follower> Create(Follower item);

		Task Update(Follower item);

		Task Delete(int id);

		Task<Follower> Get(int id);

		Task<List<Follower>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Follower>> ByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Follower>> ByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByFollowedUserId(int followedUserId);

		Task<User> UserByFollowingUserId(int followingUserId);
	}
}

/*<Codenesium>
    <Hash>01fb516965ce07e9daddff2b617c893b</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IBadgeRepository
	{
		Task<Badge> Create(Badge item);

		Task Update(Badge item);

		Task Delete(int id);

		Task<Badge> Get(int id);

		Task<List<Badge>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Badge>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>2094ae5e7f639c28d222741459e36387</Hash>
</Codenesium>*/
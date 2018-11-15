using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IFollowingRepository
	{
		Task<Following> Create(Following item);

		Task Update(Following item);

		Task Delete(int userId);

		Task<Following> Get(int userId);

		Task<List<Following>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5da8e5ef9ba14701352bf2551886c2ac</Hash>
</Codenesium>*/
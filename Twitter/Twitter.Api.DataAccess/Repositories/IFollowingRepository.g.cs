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

		Task Delete(string userId);

		Task<Following> Get(string userId);

		Task<List<Following>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2233f2a103671bbb24571c8ca10d78d8</Hash>
</Codenesium>*/
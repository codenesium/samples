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

		Task<List<Badge>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>87147502280ea7f86e16c78a9c11fdd2</Hash>
</Codenesium>*/
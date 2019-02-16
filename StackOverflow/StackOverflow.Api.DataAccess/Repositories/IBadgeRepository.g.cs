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
	}
}

/*<Codenesium>
    <Hash>a3a28030be85e1711267472bf4c4cc60</Hash>
</Codenesium>*/
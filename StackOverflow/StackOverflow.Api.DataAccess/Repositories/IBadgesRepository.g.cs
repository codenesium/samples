using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IBadgesRepository
	{
		Task<Badges> Create(Badges item);

		Task Update(Badges item);

		Task Delete(int id);

		Task<Badges> Get(int id);

		Task<List<Badges>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b320836c050dee9f7dc99a20a859628c</Hash>
</Codenesium>*/
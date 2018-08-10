using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ICommentsRepository
	{
		Task<Comments> Create(Comments item);

		Task Update(Comments item);

		Task Delete(int id);

		Task<Comments> Get(int id);

		Task<List<Comments>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2a9b63a7fd6fc4f54873e765684c692c</Hash>
</Codenesium>*/
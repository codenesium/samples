using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IVoteRepository
	{
		Task<Vote> Create(Vote item);

		Task Update(Vote item);

		Task Delete(int id);

		Task<Vote> Get(int id);

		Task<List<Vote>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Vote>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>52f683e2876bf66d7c5b56f4b829fe3a</Hash>
</Codenesium>*/
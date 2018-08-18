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
    <Hash>9f5fb3534fc402f093b4abbcd7963daf</Hash>
</Codenesium>*/
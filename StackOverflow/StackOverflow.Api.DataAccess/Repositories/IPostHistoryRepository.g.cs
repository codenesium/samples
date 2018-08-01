using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public interface IPostHistoryRepository
	{
		Task<PostHistory> Create(PostHistory item);

		Task Update(PostHistory item);

		Task Delete(int id);

		Task<PostHistory> Get(int id);

		Task<List<PostHistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>329b40c610ee7d9c8e0d4f2ed170a1ee</Hash>
</Codenesium>*/
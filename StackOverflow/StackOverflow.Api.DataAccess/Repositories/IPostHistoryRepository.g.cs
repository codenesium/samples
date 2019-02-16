using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostHistoryRepository
	{
		Task<PostHistory> Create(PostHistory item);

		Task Update(PostHistory item);

		Task Delete(int id);

		Task<PostHistory> Get(int id);

		Task<List<PostHistory>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>807ba9899f03594bbcdce9a00141b1cf</Hash>
</Codenesium>*/
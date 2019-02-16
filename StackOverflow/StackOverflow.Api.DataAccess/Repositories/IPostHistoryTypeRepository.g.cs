using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostHistoryTypeRepository
	{
		Task<PostHistoryType> Create(PostHistoryType item);

		Task Update(PostHistoryType item);

		Task Delete(int id);

		Task<PostHistoryType> Get(int id);

		Task<List<PostHistoryType>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>8d1b11b5fd884f5fe495276c129b4d72</Hash>
</Codenesium>*/
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

		Task<List<PostHistoryType>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>141e98bff5d715f42649c004ed9b4311</Hash>
</Codenesium>*/
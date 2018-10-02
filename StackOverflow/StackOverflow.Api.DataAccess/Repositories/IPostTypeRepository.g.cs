using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostTypeRepository
	{
		Task<PostType> Create(PostType item);

		Task Update(PostType item);

		Task Delete(int id);

		Task<PostType> Get(int id);

		Task<List<PostType>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>58a98d674fad65297394d9ba0dcee419</Hash>
</Codenesium>*/
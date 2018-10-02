using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostLinkRepository
	{
		Task<PostLink> Create(PostLink item);

		Task Update(PostLink item);

		Task Delete(int id);

		Task<PostLink> Get(int id);

		Task<List<PostLink>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3cf5a89f9413d849c4f04d073016c1a0</Hash>
</Codenesium>*/
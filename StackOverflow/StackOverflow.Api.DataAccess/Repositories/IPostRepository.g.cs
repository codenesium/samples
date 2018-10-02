using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostRepository
	{
		Task<Post> Create(Post item);

		Task Update(Post item);

		Task Delete(int id);

		Task<Post> Get(int id);

		Task<List<Post>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Post>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c76c2bcd4c2ff71b0e6fb01ad5bacf38</Hash>
</Codenesium>*/
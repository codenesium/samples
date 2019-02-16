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

		Task<List<Post>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Post>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>affb9fd11026d1e1c2bd4f8fbea512b9</Hash>
</Codenesium>*/
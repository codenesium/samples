using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostLinksRepository
	{
		Task<PostLinks> Create(PostLinks item);

		Task Update(PostLinks item);

		Task Delete(int id);

		Task<PostLinks> Get(int id);

		Task<List<PostLinks>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PostLinks>> ByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostLinks>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostLinks>> ByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0);

		Task<LinkTypes> LinkTypesByLinkTypeId(int linkTypeId);

		Task<Posts> PostsByPostId(int postId);

		Task<Posts> PostsByRelatedPostId(int relatedPostId);
	}
}

/*<Codenesium>
    <Hash>51148502109b6c90e06cc67f3ecf1c3a</Hash>
</Codenesium>*/
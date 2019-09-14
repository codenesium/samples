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

		Task<List<PostLink>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PostLink>> ByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostLink>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostLink>> ByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0);

		Task<LinkType> LinkTypeByLinkTypeId(int linkTypeId);

		Task<Post> PostByPostId(int postId);

		Task<Post> PostByRelatedPostId(int relatedPostId);
	}
}

/*<Codenesium>
    <Hash>7725f6879e9a09a99bda7ffc9ff4574d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
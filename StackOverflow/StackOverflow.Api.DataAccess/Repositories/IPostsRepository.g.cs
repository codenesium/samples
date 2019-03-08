using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostsRepository
	{
		Task<Posts> Create(Posts item);

		Task Update(Posts item);

		Task Delete(int id);

		Task<Posts> Get(int id);

		Task<List<Posts>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Posts>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Posts>> ByLastEditorUserId(int? lastEditorUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Posts>> ByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<Posts>> ByParentId(int? parentId, int limit = int.MaxValue, int offset = 0);

		Task<List<Comments>> CommentsByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<Posts>> PostsByParentId(int parentId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tags>> TagsByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tags>> TagsByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<Votes>> VotesByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostHistory>> PostHistoryByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostLinks>> PostLinksByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostLinks>> PostLinksByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0);

		Task<Users> UsersByLastEditorUserId(int? lastEditorUserId);

		Task<Users> UsersByOwnerUserId(int? ownerUserId);

		Task<Posts> PostsByParentId(int? parentId);

		Task<PostTypes> PostTypesByPostTypeId(int postTypeId);
	}
}

/*<Codenesium>
    <Hash>a89ebd45b63dfdbe1c85b83ff2932f15</Hash>
</Codenesium>*/
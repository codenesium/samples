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

		Task<List<Post>> ByLastEditorUserId(int? lastEditorUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Post>> ByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<Post>> ByParentId(int? parentId, int limit = int.MaxValue, int offset = 0);

		Task<List<Comment>> CommentsByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<Post>> PostsByParentId(int parentId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tag>> TagsByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<Tag>> TagsByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<Vote>> VotesByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostHistory>> PostHistoriesByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostLink>> PostLinksByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<PostLink>> PostLinksByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserByLastEditorUserId(int? lastEditorUserId);

		Task<User> UserByOwnerUserId(int? ownerUserId);

		Task<Post> PostByParentId(int? parentId);

		Task<PostType> PostTypeByPostTypeId(int postTypeId);
	}
}

/*<Codenesium>
    <Hash>d47b42e1aed3d2464246cb5431d56e82</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
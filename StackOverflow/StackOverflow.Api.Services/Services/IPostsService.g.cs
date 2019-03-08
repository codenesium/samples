using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostsService
	{
		Task<CreateResponse<ApiPostsServerResponseModel>> Create(
			ApiPostsServerRequestModel model);

		Task<UpdateResponse<ApiPostsServerResponseModel>> Update(int id,
		                                                          ApiPostsServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostsServerResponseModel> Get(int id);

		Task<List<ApiPostsServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostsServerResponseModel>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostsServerResponseModel>> ByLastEditorUserId(int? lastEditorUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostsServerResponseModel>> ByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostsServerResponseModel>> ByParentId(int? parentId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCommentsServerResponseModel>> CommentsByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostsServerResponseModel>> PostsByParentId(int parentId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTagsServerResponseModel>> TagsByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTagsServerResponseModel>> TagsByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVotesServerResponseModel>> VotesByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostHistoryServerResponseModel>> PostHistoryByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostLinksServerResponseModel>> PostLinksByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostLinksServerResponseModel>> PostLinksByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c2f3bae50bfabef9e0f601e628239f9f</Hash>
</Codenesium>*/
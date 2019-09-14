using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostService
	{
		Task<CreateResponse<ApiPostServerResponseModel>> Create(
			ApiPostServerRequestModel model);

		Task<UpdateResponse<ApiPostServerResponseModel>> Update(int id,
		                                                         ApiPostServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostServerResponseModel> Get(int id);

		Task<List<ApiPostServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostServerResponseModel>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostServerResponseModel>> ByLastEditorUserId(int? lastEditorUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostServerResponseModel>> ByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostServerResponseModel>> ByParentId(int? parentId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCommentServerResponseModel>> CommentsByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostServerResponseModel>> PostsByParentId(int parentId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTagServerResponseModel>> TagsByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTagServerResponseModel>> TagsByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVoteServerResponseModel>> VotesByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostHistoryServerResponseModel>> PostHistoriesByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostLinkServerResponseModel>> PostLinksByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostLinkServerResponseModel>> PostLinksByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>12bf56128056b23c64302eaa3593f53b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
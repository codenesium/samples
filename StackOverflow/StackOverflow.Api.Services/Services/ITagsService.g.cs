using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ITagsService
	{
		Task<CreateResponse<ApiTagsServerResponseModel>> Create(
			ApiTagsServerRequestModel model);

		Task<UpdateResponse<ApiTagsServerResponseModel>> Update(int id,
		                                                         ApiTagsServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTagsServerResponseModel> Get(int id);

		Task<List<ApiTagsServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTagsServerResponseModel>> ByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTagsServerResponseModel>> ByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7056a0f46a172e5f8580db28e18188cd</Hash>
</Codenesium>*/
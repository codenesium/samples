using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ITagService
	{
		Task<CreateResponse<ApiTagServerResponseModel>> Create(
			ApiTagServerRequestModel model);

		Task<UpdateResponse<ApiTagServerResponseModel>> Update(int id,
		                                                        ApiTagServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTagServerResponseModel> Get(int id);

		Task<List<ApiTagServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTagServerResponseModel>> ByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTagServerResponseModel>> ByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e06d3e028ba5912e4c4d49504f908057</Hash>
</Codenesium>*/
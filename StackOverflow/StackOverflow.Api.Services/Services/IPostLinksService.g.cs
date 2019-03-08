using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostLinksService
	{
		Task<CreateResponse<ApiPostLinksServerResponseModel>> Create(
			ApiPostLinksServerRequestModel model);

		Task<UpdateResponse<ApiPostLinksServerResponseModel>> Update(int id,
		                                                              ApiPostLinksServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostLinksServerResponseModel> Get(int id);

		Task<List<ApiPostLinksServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostLinksServerResponseModel>> ByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostLinksServerResponseModel>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostLinksServerResponseModel>> ByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>00ba2cf3c307793894b9f4dfe9d726b3</Hash>
</Codenesium>*/
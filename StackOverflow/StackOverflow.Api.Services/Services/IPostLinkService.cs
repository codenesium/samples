using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostLinkService
	{
		Task<CreateResponse<ApiPostLinkServerResponseModel>> Create(
			ApiPostLinkServerRequestModel model);

		Task<UpdateResponse<ApiPostLinkServerResponseModel>> Update(int id,
		                                                             ApiPostLinkServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostLinkServerResponseModel> Get(int id);

		Task<List<ApiPostLinkServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostLinkServerResponseModel>> ByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostLinkServerResponseModel>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostLinkServerResponseModel>> ByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1512e3e4f594d8fabbd9439b80c4b768</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
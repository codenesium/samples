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
	}
}

/*<Codenesium>
    <Hash>a91d34d421fd64a2b9b1511cf3a6d652</Hash>
</Codenesium>*/
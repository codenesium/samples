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

		Task<List<ApiPostLinkServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dc8f6b5af619ad0717525fcb03e6b161</Hash>
</Codenesium>*/
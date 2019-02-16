using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IQuoteTweetService
	{
		Task<CreateResponse<ApiQuoteTweetServerResponseModel>> Create(
			ApiQuoteTweetServerRequestModel model);

		Task<UpdateResponse<ApiQuoteTweetServerResponseModel>> Update(int quoteTweetId,
		                                                               ApiQuoteTweetServerRequestModel model);

		Task<ActionResponse> Delete(int quoteTweetId);

		Task<ApiQuoteTweetServerResponseModel> Get(int quoteTweetId);

		Task<List<ApiQuoteTweetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiQuoteTweetServerResponseModel>> ByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetServerResponseModel>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>984a4899a32ebe5d40b0b78f784c122f</Hash>
</Codenesium>*/
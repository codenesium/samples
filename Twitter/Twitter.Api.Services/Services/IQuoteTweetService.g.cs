using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IQuoteTweetService
	{
		Task<CreateResponse<ApiQuoteTweetResponseModel>> Create(
			ApiQuoteTweetRequestModel model);

		Task<UpdateResponse<ApiQuoteTweetResponseModel>> Update(int quoteTweetId,
		                                                         ApiQuoteTweetRequestModel model);

		Task<ActionResponse> Delete(int quoteTweetId);

		Task<ApiQuoteTweetResponseModel> Get(int quoteTweetId);

		Task<List<ApiQuoteTweetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetResponseModel>> ByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiQuoteTweetResponseModel>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>33c093cb859ac5b00def3389c2efd9f1</Hash>
</Codenesium>*/
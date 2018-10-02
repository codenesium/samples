using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IFollowingService
	{
		Task<CreateResponse<ApiFollowingResponseModel>> Create(
			ApiFollowingRequestModel model);

		Task<UpdateResponse<ApiFollowingResponseModel>> Update(string userId,
		                                                        ApiFollowingRequestModel model);

		Task<ActionResponse> Delete(string userId);

		Task<ApiFollowingResponseModel> Get(string userId);

		Task<List<ApiFollowingResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5c2e23ba2b5bcd4ca77a9a6de1263abc</Hash>
</Codenesium>*/
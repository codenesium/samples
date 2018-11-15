using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IFollowingService
	{
		Task<CreateResponse<ApiFollowingServerResponseModel>> Create(
			ApiFollowingServerRequestModel model);

		Task<UpdateResponse<ApiFollowingServerResponseModel>> Update(int userId,
		                                                              ApiFollowingServerRequestModel model);

		Task<ActionResponse> Delete(int userId);

		Task<ApiFollowingServerResponseModel> Get(int userId);

		Task<List<ApiFollowingServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f9e18e4b054b3ed6ad8fbfb8ff930280</Hash>
</Codenesium>*/
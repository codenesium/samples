using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IFollowerService
	{
		Task<CreateResponse<ApiFollowerServerResponseModel>> Create(
			ApiFollowerServerRequestModel model);

		Task<UpdateResponse<ApiFollowerServerResponseModel>> Update(int id,
		                                                             ApiFollowerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFollowerServerResponseModel> Get(int id);

		Task<List<ApiFollowerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiFollowerServerResponseModel>> ByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFollowerServerResponseModel>> ByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>74b28f6d78ecca1bb6f47515e83a12e4</Hash>
</Codenesium>*/
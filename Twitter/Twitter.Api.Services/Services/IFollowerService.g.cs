using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IFollowerService
	{
		Task<CreateResponse<ApiFollowerResponseModel>> Create(
			ApiFollowerRequestModel model);

		Task<UpdateResponse<ApiFollowerResponseModel>> Update(int id,
		                                                       ApiFollowerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFollowerResponseModel> Get(int id);

		Task<List<ApiFollowerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFollowerResponseModel>> ByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiFollowerResponseModel>> ByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>12224b156eff2beed073048b71a916ad</Hash>
</Codenesium>*/
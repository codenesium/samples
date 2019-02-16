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

		Task<List<ApiFollowingServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>2c911ae5a0806840fb831919b089373f</Hash>
</Codenesium>*/
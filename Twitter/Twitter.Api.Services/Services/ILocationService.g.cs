using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface ILocationService
	{
		Task<CreateResponse<ApiLocationServerResponseModel>> Create(
			ApiLocationServerRequestModel model);

		Task<UpdateResponse<ApiLocationServerResponseModel>> Update(int locationId,
		                                                             ApiLocationServerRequestModel model);

		Task<ActionResponse> Delete(int locationId);

		Task<ApiLocationServerResponseModel> Get(int locationId);

		Task<List<ApiLocationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTweetServerResponseModel>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserServerResponseModel>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7aaf1be5d03202cd5140e0f98eac64e2</Hash>
</Codenesium>*/
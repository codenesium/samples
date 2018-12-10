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

		Task<List<ApiLocationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetServerResponseModel>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserServerResponseModel>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e960775d861e79cdfff2aeb00b9c1196</Hash>
</Codenesium>*/
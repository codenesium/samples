using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface ILocationService
	{
		Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model);

		Task<UpdateResponse<ApiLocationResponseModel>> Update(int locationId,
		                                                       ApiLocationRequestModel model);

		Task<ActionResponse> Delete(int locationId);

		Task<ApiLocationResponseModel> Get(int locationId);

		Task<List<ApiLocationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTweetResponseModel>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserResponseModel>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>16e033e89a70b2b36f523ffd62814000</Hash>
</Codenesium>*/
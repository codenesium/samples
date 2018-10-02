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

		Task<List<ApiTweetResponseModel>> Tweets(int locationId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUserResponseModel>> Users(int locationLocationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d87ce41e4cc9fd48d4294c09731bc416</Hash>
</Codenesium>*/
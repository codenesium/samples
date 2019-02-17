using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IRateService
	{
		Task<CreateResponse<ApiRateServerResponseModel>> Create(
			ApiRateServerRequestModel model);

		Task<UpdateResponse<ApiRateServerResponseModel>> Update(int id,
		                                                         ApiRateServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRateServerResponseModel> Get(int id);

		Task<List<ApiRateServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>b8ffb9bc7c54c344fab5fc519b7748e8</Hash>
</Codenesium>*/
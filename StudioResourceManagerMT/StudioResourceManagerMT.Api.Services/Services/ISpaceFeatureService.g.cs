using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface ISpaceFeatureService
	{
		Task<CreateResponse<ApiSpaceFeatureServerResponseModel>> Create(
			ApiSpaceFeatureServerRequestModel model);

		Task<UpdateResponse<ApiSpaceFeatureServerResponseModel>> Update(int id,
		                                                                 ApiSpaceFeatureServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceFeatureServerResponseModel> Get(int id);

		Task<List<ApiSpaceFeatureServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>c74d0f4fcec333456e95d5c511301e14</Hash>
</Codenesium>*/
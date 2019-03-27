using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface ISpaceSpaceFeatureService
	{
		Task<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>> Create(
			ApiSpaceSpaceFeatureServerRequestModel model);

		Task<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>> Update(int spaceId,
		                                                                      ApiSpaceSpaceFeatureServerRequestModel model);

		Task<ActionResponse> Delete(int spaceId);

		Task<ApiSpaceSpaceFeatureServerResponseModel> Get(int spaceId);

		Task<List<ApiSpaceSpaceFeatureServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>18f7b008aa45e2ec427b48e67a5f6eec</Hash>
</Codenesium>*/
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

		Task<List<ApiSpaceSpaceFeatureServerResponseModel>> SpaceSpaceFeaturesBySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ce251d85e8e011dc1caf021ecacb6422</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
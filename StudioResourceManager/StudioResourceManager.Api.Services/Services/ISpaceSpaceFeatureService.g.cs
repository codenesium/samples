using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ISpaceSpaceFeatureService
	{
		Task<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>> Create(
			ApiSpaceSpaceFeatureServerRequestModel model);

		Task<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>> Update(int id,
		                                                                      ApiSpaceSpaceFeatureServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceSpaceFeatureServerResponseModel> Get(int id);

		Task<List<ApiSpaceSpaceFeatureServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiSpaceSpaceFeatureServerResponseModel>> BySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceSpaceFeatureServerResponseModel>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>be5d58d04332cbbab64732140d599fed</Hash>
</Codenesium>*/
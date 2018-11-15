using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ISpaceFeatureService
	{
		Task<CreateResponse<ApiSpaceFeatureServerResponseModel>> Create(
			ApiSpaceFeatureServerRequestModel model);

		Task<UpdateResponse<ApiSpaceFeatureServerResponseModel>> Update(int id,
		                                                                 ApiSpaceFeatureServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceFeatureServerResponseModel> Get(int id);

		Task<List<ApiSpaceFeatureServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceFeatureServerResponseModel>> BySpaceId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f80d5b4e462e1df1d2c074c960ce935b</Hash>
</Codenesium>*/
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ISpaceSpaceFeatureService
	{
		Task<CreateResponse<ApiSpaceSpaceFeatureResponseModel>> Create(
			ApiSpaceSpaceFeatureRequestModel model);

		Task<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>> Update(int id,
		                                                                ApiSpaceSpaceFeatureRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceSpaceFeatureResponseModel> Get(int id);

		Task<List<ApiSpaceSpaceFeatureResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceSpaceFeatureResponseModel>> BySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceSpaceFeatureResponseModel>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f42e95d93bf727710cdd6ca00a013ae8</Hash>
</Codenesium>*/
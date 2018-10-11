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

		Task<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>> Update(int spaceId,
		                                                                ApiSpaceSpaceFeatureRequestModel model);

		Task<ActionResponse> Delete(int spaceId);

		Task<ApiSpaceSpaceFeatureResponseModel> Get(int spaceId);

		Task<List<ApiSpaceSpaceFeatureResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>33c44a90e16f3117ef27968b43a3b86e</Hash>
</Codenesium>*/
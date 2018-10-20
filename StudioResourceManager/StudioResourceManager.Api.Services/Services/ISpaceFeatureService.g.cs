using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ISpaceFeatureService
	{
		Task<CreateResponse<ApiSpaceFeatureResponseModel>> Create(
			ApiSpaceFeatureRequestModel model);

		Task<UpdateResponse<ApiSpaceFeatureResponseModel>> Update(int id,
		                                                           ApiSpaceFeatureRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceFeatureResponseModel> Get(int id);

		Task<List<ApiSpaceFeatureResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceSpaceFeatureResponseModel>> SpaceSpaceFeaturesBySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d7b337aa3f758c6bf8704d8656c679ee</Hash>
</Codenesium>*/
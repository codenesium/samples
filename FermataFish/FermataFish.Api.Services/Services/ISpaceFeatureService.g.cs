using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
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

		Task<List<ApiSpaceFeatureResponseModel>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2fc739fd94f13c10f3431b581383b36b</Hash>
</Codenesium>*/
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface ISpaceService
	{
		Task<CreateResponse<ApiSpaceResponseModel>> Create(
			ApiSpaceRequestModel model);

		Task<UpdateResponse<ApiSpaceResponseModel>> Update(int id,
		                                                    ApiSpaceRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceResponseModel> Get(int id);

		Task<List<ApiSpaceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>aed2ad8d943aab420416fb2ea109583d</Hash>
</Codenesium>*/
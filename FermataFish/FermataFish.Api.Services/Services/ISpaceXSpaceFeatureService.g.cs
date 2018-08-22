using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface ISpaceXSpaceFeatureService
	{
		Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> Create(
			ApiSpaceXSpaceFeatureRequestModel model);

		Task<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>> Update(int id,
		                                                                 ApiSpaceXSpaceFeatureRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceXSpaceFeatureResponseModel> Get(int id);

		Task<List<ApiSpaceXSpaceFeatureResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSpaceXSpaceFeatureResponseModel>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>92bdf0f4ff4ddfe1739f7a62f55611a4</Hash>
</Codenesium>*/
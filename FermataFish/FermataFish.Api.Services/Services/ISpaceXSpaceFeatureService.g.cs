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
	}
}

/*<Codenesium>
    <Hash>3d46ecb1824721be3664889868c16d46</Hash>
</Codenesium>*/
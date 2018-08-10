using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiSpaceXSpaceFeatureModelMapper
	{
		ApiSpaceXSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceXSpaceFeatureRequestModel request);

		ApiSpaceXSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceXSpaceFeatureResponseModel response);

		JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> CreatePatch(ApiSpaceXSpaceFeatureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>593fbef832ec58ae48d0017d1d177e83</Hash>
</Codenesium>*/
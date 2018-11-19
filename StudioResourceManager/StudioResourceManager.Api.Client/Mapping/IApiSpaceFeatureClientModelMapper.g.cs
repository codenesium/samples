using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiSpaceFeatureModelMapper
	{
		ApiSpaceFeatureClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceFeatureClientRequestModel request);

		ApiSpaceFeatureClientRequestModel MapClientResponseToRequest(
			ApiSpaceFeatureClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>1d39b1bec70884718676c65aeaaf552f</Hash>
</Codenesium>*/
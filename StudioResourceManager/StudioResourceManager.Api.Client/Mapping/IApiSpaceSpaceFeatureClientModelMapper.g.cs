using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiSpaceSpaceFeatureModelMapper
	{
		ApiSpaceSpaceFeatureClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceSpaceFeatureClientRequestModel request);

		ApiSpaceSpaceFeatureClientRequestModel MapClientResponseToRequest(
			ApiSpaceSpaceFeatureClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a97c1d6ada1391f2c614b4c8a7fd4df9</Hash>
</Codenesium>*/
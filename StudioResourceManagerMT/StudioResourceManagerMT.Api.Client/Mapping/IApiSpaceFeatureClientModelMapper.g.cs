using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>33b7a20d1f1e0d58d70e0d9a9ec3e166</Hash>
</Codenesium>*/
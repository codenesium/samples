using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiSpaceSpaceFeatureModelMapper
	{
		ApiSpaceSpaceFeatureClientResponseModel MapClientRequestToResponse(
			int spaceId,
			ApiSpaceSpaceFeatureClientRequestModel request);

		ApiSpaceSpaceFeatureClientRequestModel MapClientResponseToRequest(
			ApiSpaceSpaceFeatureClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>cec31b706d1b5518da667f2fc89b748e</Hash>
</Codenesium>*/
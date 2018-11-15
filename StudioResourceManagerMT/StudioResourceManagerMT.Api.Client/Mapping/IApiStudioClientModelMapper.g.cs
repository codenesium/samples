using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiStudioModelMapper
	{
		ApiStudioClientResponseModel MapClientRequestToResponse(
			int id,
			ApiStudioClientRequestModel request);

		ApiStudioClientRequestModel MapClientResponseToRequest(
			ApiStudioClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>ffdd9c846d46c7157ba4f3ef1e7d08ed</Hash>
</Codenesium>*/
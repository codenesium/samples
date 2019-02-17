using StudioResourceManagerMTNS.Api.Contracts;
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
    <Hash>2141727d01e3b7a3091dc90fb645a331</Hash>
</Codenesium>*/
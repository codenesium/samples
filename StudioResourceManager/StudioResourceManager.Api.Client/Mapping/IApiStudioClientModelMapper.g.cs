using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>8c29b04e6fb82e610ab5603af488aca2</Hash>
</Codenesium>*/
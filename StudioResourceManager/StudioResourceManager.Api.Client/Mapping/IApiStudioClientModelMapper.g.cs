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
    <Hash>572ea26ca25ec2144a25c3f7dec9e3c0</Hash>
</Codenesium>*/
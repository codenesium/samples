using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiUserModelMapper
	{
		ApiUserClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUserClientRequestModel request);

		ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b2e886d05d832a0ce41db0f1702be949</Hash>
</Codenesium>*/
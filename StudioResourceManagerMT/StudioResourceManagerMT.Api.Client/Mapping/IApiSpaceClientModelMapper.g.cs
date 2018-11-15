using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiSpaceModelMapper
	{
		ApiSpaceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceClientRequestModel request);

		ApiSpaceClientRequestModel MapClientResponseToRequest(
			ApiSpaceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>30ee2d8aa93bef151f8e28d7f3a78640</Hash>
</Codenesium>*/
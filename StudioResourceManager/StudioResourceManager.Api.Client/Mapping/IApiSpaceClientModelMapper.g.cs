using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>2fe57ac9641abf82ff17054e97f3fb48</Hash>
</Codenesium>*/
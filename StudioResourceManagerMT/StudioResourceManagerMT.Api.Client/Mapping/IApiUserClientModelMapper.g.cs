using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>5aa660a60ed08083a74079d57a402692</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiEventModelMapper
	{
		ApiEventClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventClientRequestModel request);

		ApiEventClientRequestModel MapClientResponseToRequest(
			ApiEventClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>977bf5ae2fcb7f986d9ba914fb694632</Hash>
</Codenesium>*/
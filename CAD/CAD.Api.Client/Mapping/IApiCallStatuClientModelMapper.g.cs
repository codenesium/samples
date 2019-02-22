using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiCallStatuModelMapper
	{
		ApiCallStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallStatuClientRequestModel request);

		ApiCallStatuClientRequestModel MapClientResponseToRequest(
			ApiCallStatuClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>03b7229f91eb3c04a2d55c5d64852079</Hash>
</Codenesium>*/
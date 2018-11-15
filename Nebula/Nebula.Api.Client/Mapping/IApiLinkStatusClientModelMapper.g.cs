using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiLinkStatusModelMapper
	{
		ApiLinkStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkStatusClientRequestModel request);

		ApiLinkStatusClientRequestModel MapClientResponseToRequest(
			ApiLinkStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0d0ef38134b82db2662f82f6cdf29a53</Hash>
</Codenesium>*/
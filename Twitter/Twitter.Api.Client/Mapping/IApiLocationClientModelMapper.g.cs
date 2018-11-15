using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiLocationModelMapper
	{
		ApiLocationClientResponseModel MapClientRequestToResponse(
			int locationId,
			ApiLocationClientRequestModel request);

		ApiLocationClientRequestModel MapClientResponseToRequest(
			ApiLocationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>53a1a23af30f35f563182065ab92ad27</Hash>
</Codenesium>*/
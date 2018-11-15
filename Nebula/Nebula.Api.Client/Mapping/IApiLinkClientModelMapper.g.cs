using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiLinkModelMapper
	{
		ApiLinkClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkClientRequestModel request);

		ApiLinkClientRequestModel MapClientResponseToRequest(
			ApiLinkClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a2f34b76f341a8b6127a97d0a2993241</Hash>
</Codenesium>*/
using NebulaNS.Api.Contracts;
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
    <Hash>62915455dc04ef8e9652810bf2b4b356</Hash>
</Codenesium>*/
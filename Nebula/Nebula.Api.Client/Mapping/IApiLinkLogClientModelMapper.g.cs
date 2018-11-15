using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiLinkLogModelMapper
	{
		ApiLinkLogClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkLogClientRequestModel request);

		ApiLinkLogClientRequestModel MapClientResponseToRequest(
			ApiLinkLogClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>abb627304071ff6658ce139d052c3cc7</Hash>
</Codenesium>*/
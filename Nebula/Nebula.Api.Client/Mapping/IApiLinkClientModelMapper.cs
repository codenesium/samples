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
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
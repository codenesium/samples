using NebulaNS.Api.Contracts;
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
    <Hash>03e78582569fe08dd8d23c2b1ee84cb8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
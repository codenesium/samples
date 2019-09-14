using NebulaNS.Api.Contracts;
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
    <Hash>ef1f5cc90c7f0d93be3d721e21baf49e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
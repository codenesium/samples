using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiUserModelMapper
	{
		ApiUserClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUserClientRequestModel request);

		ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>78562d779888e884a91a2b3f0cf55f5c</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiLinkTypeModelMapper
	{
		ApiLinkTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkTypeClientRequestModel request);

		ApiLinkTypeClientRequestModel MapClientResponseToRequest(
			ApiLinkTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>da61c1a201b75c4a5dfe954dd65292a8</Hash>
</Codenesium>*/
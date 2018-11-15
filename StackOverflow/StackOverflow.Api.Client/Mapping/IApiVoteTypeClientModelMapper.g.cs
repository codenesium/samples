using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiVoteTypeModelMapper
	{
		ApiVoteTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVoteTypeClientRequestModel request);

		ApiVoteTypeClientRequestModel MapClientResponseToRequest(
			ApiVoteTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2e1d98e6b8587ee1b34c2031a374f187</Hash>
</Codenesium>*/
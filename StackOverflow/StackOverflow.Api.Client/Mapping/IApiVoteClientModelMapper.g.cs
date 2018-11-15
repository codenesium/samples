using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiVoteModelMapper
	{
		ApiVoteClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVoteClientRequestModel request);

		ApiVoteClientRequestModel MapClientResponseToRequest(
			ApiVoteClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7614dced3e6bbeba5c13dc3b9ea511fe</Hash>
</Codenesium>*/
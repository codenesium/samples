using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiVoteTypesModelMapper
	{
		ApiVoteTypesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVoteTypesClientRequestModel request);

		ApiVoteTypesClientRequestModel MapClientResponseToRequest(
			ApiVoteTypesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>58d661532cd0d791f71a65c455dcc7d7</Hash>
</Codenesium>*/
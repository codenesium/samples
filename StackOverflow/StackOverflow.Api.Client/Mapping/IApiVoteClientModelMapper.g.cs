using StackOverflowNS.Api.Contracts;
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
    <Hash>b83a1371aa5b5daf141eb636857a9101</Hash>
</Codenesium>*/
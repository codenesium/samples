using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiVotesModelMapper
	{
		ApiVotesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVotesClientRequestModel request);

		ApiVotesClientRequestModel MapClientResponseToRequest(
			ApiVotesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>715eb91c93eced1986d12580221ab4e7</Hash>
</Codenesium>*/
using StackOverflowNS.Api.Contracts;
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
    <Hash>8e9bb9d6871f0363cecf19f6247fadda</Hash>
</Codenesium>*/
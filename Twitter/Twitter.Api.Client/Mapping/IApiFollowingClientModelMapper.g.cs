using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Client
{
	public partial interface IApiFollowingModelMapper
	{
		ApiFollowingClientResponseModel MapClientRequestToResponse(
			int userId,
			ApiFollowingClientRequestModel request);

		ApiFollowingClientRequestModel MapClientResponseToRequest(
			ApiFollowingClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>e6d4e64f4e9773a6d6c68d3fd259bd32</Hash>
</Codenesium>*/
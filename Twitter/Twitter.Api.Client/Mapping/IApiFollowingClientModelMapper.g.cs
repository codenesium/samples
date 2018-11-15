using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    <Hash>ff12285f484c8b802aafb2a0cfc66b6e</Hash>
</Codenesium>*/
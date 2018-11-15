using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiFollowerModelMapper
	{
		ApiFollowerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFollowerClientRequestModel request);

		ApiFollowerClientRequestModel MapClientResponseToRequest(
			ApiFollowerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3ac668bd0096af8ff9a3504ae6879448</Hash>
</Codenesium>*/
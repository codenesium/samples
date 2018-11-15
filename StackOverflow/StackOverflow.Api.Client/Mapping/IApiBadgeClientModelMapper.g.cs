using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiBadgeModelMapper
	{
		ApiBadgeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBadgeClientRequestModel request);

		ApiBadgeClientRequestModel MapClientResponseToRequest(
			ApiBadgeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>baee6243068c1fe8bcff99ab405258d5</Hash>
</Codenesium>*/
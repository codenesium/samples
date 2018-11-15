using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiRetweetModelMapper
	{
		ApiRetweetClientResponseModel MapClientRequestToResponse(
			int id,
			ApiRetweetClientRequestModel request);

		ApiRetweetClientRequestModel MapClientResponseToRequest(
			ApiRetweetClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>996cab6bc6e597996d5241bee6b2035b</Hash>
</Codenesium>*/
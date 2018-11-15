using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiMessengerModelMapper
	{
		ApiMessengerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiMessengerClientRequestModel request);

		ApiMessengerClientRequestModel MapClientResponseToRequest(
			ApiMessengerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>47ea54af5e0bb8c15a065e1050942a8c</Hash>
</Codenesium>*/
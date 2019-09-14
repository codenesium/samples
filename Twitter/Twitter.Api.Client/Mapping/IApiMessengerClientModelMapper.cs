using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

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
    <Hash>e807321f4be7488c56f8d336bd92283f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
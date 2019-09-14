using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiCityModelMapper
	{
		ApiCityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCityClientRequestModel request);

		ApiCityClientRequestModel MapClientResponseToRequest(
			ApiCityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7d1731d81e73458e39ed279dd688903c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
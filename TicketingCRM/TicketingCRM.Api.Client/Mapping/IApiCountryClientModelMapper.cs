using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiCountryModelMapper
	{
		ApiCountryClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCountryClientRequestModel request);

		ApiCountryClientRequestModel MapClientResponseToRequest(
			ApiCountryClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b6f23aa090033a210ceff71c0bf6aaec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    <Hash>8b47a246f3156b321568ac3cc0d03476</Hash>
</Codenesium>*/
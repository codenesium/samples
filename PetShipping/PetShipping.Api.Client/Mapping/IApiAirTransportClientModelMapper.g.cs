using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiAirTransportModelMapper
	{
		ApiAirTransportClientResponseModel MapClientRequestToResponse(
			int airlineId,
			ApiAirTransportClientRequestModel request);

		ApiAirTransportClientRequestModel MapClientResponseToRequest(
			ApiAirTransportClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>ac5ff154d1750fe1c42f1f6afecf46fb</Hash>
</Codenesium>*/
using PetShippingNS.Api.Contracts;
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
    <Hash>6d38eee67a4c3850ba8a2fd0a17ff580</Hash>
</Codenesium>*/
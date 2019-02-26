using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiAirTransportModelMapper
	{
		ApiAirTransportClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAirTransportClientRequestModel request);

		ApiAirTransportClientRequestModel MapClientResponseToRequest(
			ApiAirTransportClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c7491681a26215edff12d675f29b5c6a</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiAirlineModelMapper
	{
		ApiAirlineClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAirlineClientRequestModel request);

		ApiAirlineClientRequestModel MapClientResponseToRequest(
			ApiAirlineClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>676e558b8a16cbe97b8db81668e3287a</Hash>
</Codenesium>*/
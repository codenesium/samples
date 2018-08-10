using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiAirTransportModelMapper
	{
		ApiAirTransportResponseModel MapRequestToResponse(
			int airlineId,
			ApiAirTransportRequestModel request);

		ApiAirTransportRequestModel MapResponseToRequest(
			ApiAirTransportResponseModel response);

		JsonPatchDocument<ApiAirTransportRequestModel> CreatePatch(ApiAirTransportRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d44e5d1b059b03063c8125c08fe8c87a</Hash>
</Codenesium>*/
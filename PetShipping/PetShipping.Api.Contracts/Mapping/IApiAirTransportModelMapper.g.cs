using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiAirTransportModelMapper
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
    <Hash>c5ff158ad59b82d7f11e4614a7fb1164</Hash>
</Codenesium>*/
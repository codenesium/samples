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
    <Hash>793606ab7994bc678a055e4e510cc968</Hash>
</Codenesium>*/
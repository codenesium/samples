using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiAirTransportServerModelMapper
	{
		ApiAirTransportServerResponseModel MapServerRequestToResponse(
			int airlineId,
			ApiAirTransportServerRequestModel request);

		ApiAirTransportServerRequestModel MapServerResponseToRequest(
			ApiAirTransportServerResponseModel response);

		ApiAirTransportClientRequestModel MapServerResponseToClientRequest(
			ApiAirTransportServerResponseModel response);

		JsonPatchDocument<ApiAirTransportServerRequestModel> CreatePatch(ApiAirTransportServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0e5473e0d076ccbdb2531a11c07d63e9</Hash>
</Codenesium>*/
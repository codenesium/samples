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
			int id,
			ApiAirTransportServerRequestModel request);

		ApiAirTransportServerRequestModel MapServerResponseToRequest(
			ApiAirTransportServerResponseModel response);

		ApiAirTransportClientRequestModel MapServerResponseToClientRequest(
			ApiAirTransportServerResponseModel response);

		JsonPatchDocument<ApiAirTransportServerRequestModel> CreatePatch(ApiAirTransportServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>43a5877376cd49b683844939f99edadb</Hash>
</Codenesium>*/
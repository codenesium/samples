using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiVenueServerModelMapper
	{
		ApiVenueServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVenueServerRequestModel request);

		ApiVenueServerRequestModel MapServerResponseToRequest(
			ApiVenueServerResponseModel response);

		ApiVenueClientRequestModel MapServerResponseToClientRequest(
			ApiVenueServerResponseModel response);

		JsonPatchDocument<ApiVenueServerRequestModel> CreatePatch(ApiVenueServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ae3a09a902938e60b4cced09176e7ec1</Hash>
</Codenesium>*/
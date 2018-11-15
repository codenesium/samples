using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiCityServerModelMapper
	{
		ApiCityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCityServerRequestModel request);

		ApiCityServerRequestModel MapServerResponseToRequest(
			ApiCityServerResponseModel response);

		ApiCityClientRequestModel MapServerResponseToClientRequest(
			ApiCityServerResponseModel response);

		JsonPatchDocument<ApiCityServerRequestModel> CreatePatch(ApiCityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5b61507d3b1d59f5ab939fe7ae2591ca</Hash>
</Codenesium>*/
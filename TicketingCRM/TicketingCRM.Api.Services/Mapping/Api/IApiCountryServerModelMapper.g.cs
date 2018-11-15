using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiCountryServerModelMapper
	{
		ApiCountryServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCountryServerRequestModel request);

		ApiCountryServerRequestModel MapServerResponseToRequest(
			ApiCountryServerResponseModel response);

		ApiCountryClientRequestModel MapServerResponseToClientRequest(
			ApiCountryServerResponseModel response);

		JsonPatchDocument<ApiCountryServerRequestModel> CreatePatch(ApiCountryServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>faa91138bf34687a1fe6e9288b5dd974</Hash>
</Codenesium>*/
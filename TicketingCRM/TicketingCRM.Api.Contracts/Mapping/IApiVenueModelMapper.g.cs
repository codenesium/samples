using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiVenueModelMapper
	{
		ApiVenueResponseModel MapRequestToResponse(
			int id,
			ApiVenueRequestModel request);

		ApiVenueRequestModel MapResponseToRequest(
			ApiVenueResponseModel response);

		JsonPatchDocument<ApiVenueRequestModel> CreatePatch(ApiVenueRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e54f859ea78add822dfe39bde4fab6d8</Hash>
</Codenesium>*/
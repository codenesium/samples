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
    <Hash>284fac1cdeadf205621d52a8a45f3adf</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiVenueModelMapper
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
    <Hash>45bf0f122fce9765c315977b64beb974</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiEventModelMapper
	{
		ApiEventResponseModel MapRequestToResponse(
			int id,
			ApiEventRequestModel request);

		ApiEventRequestModel MapResponseToRequest(
			ApiEventResponseModel response);

		JsonPatchDocument<ApiEventRequestModel> CreatePatch(ApiEventRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6a10265a793a119cd389d33ce17cf9ea</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiEventModelMapper
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
    <Hash>8756fa05eb05a40ee254c11d7052661b</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiTicketStatusModelMapper
	{
		ApiTicketStatusResponseModel MapRequestToResponse(
			int id,
			ApiTicketStatusRequestModel request);

		ApiTicketStatusRequestModel MapResponseToRequest(
			ApiTicketStatusResponseModel response);

		JsonPatchDocument<ApiTicketStatusRequestModel> CreatePatch(ApiTicketStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>37a6b54969cf70b532b8b3bdc142b5a2</Hash>
</Codenesium>*/
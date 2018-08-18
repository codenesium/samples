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
    <Hash>af9f260090eb0b8f277d78f786a5ba9b</Hash>
</Codenesium>*/
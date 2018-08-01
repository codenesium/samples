using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiTicketStatusModelMapper
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
    <Hash>f2a5cccbc66414df2fe35d0b655efb5d</Hash>
</Codenesium>*/
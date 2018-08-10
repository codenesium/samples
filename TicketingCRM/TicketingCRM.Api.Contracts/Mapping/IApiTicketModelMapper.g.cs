using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiTicketModelMapper
	{
		ApiTicketResponseModel MapRequestToResponse(
			int id,
			ApiTicketRequestModel request);

		ApiTicketRequestModel MapResponseToRequest(
			ApiTicketResponseModel response);

		JsonPatchDocument<ApiTicketRequestModel> CreatePatch(ApiTicketRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9cac8826885b31c48216dc977702c1d7</Hash>
</Codenesium>*/
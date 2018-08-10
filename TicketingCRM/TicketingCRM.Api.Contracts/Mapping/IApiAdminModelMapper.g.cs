using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiAdminModelMapper
	{
		ApiAdminResponseModel MapRequestToResponse(
			int id,
			ApiAdminRequestModel request);

		ApiAdminRequestModel MapResponseToRequest(
			ApiAdminResponseModel response);

		JsonPatchDocument<ApiAdminRequestModel> CreatePatch(ApiAdminRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2ba6537f1b92397bdaae442da229a76b</Hash>
</Codenesium>*/
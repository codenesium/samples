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
    <Hash>df7e04e7cfe18a4f47360339646b7347</Hash>
</Codenesium>*/
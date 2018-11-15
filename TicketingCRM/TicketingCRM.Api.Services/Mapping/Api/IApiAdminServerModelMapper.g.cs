using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiAdminServerModelMapper
	{
		ApiAdminServerResponseModel MapServerRequestToResponse(
			int id,
			ApiAdminServerRequestModel request);

		ApiAdminServerRequestModel MapServerResponseToRequest(
			ApiAdminServerResponseModel response);

		ApiAdminClientRequestModel MapServerResponseToClientRequest(
			ApiAdminServerResponseModel response);

		JsonPatchDocument<ApiAdminServerRequestModel> CreatePatch(ApiAdminServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3bfb167822976d66e1080aa8523646c9</Hash>
</Codenesium>*/
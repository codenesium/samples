using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>618bb000316ed92e511e3c08386f7797</Hash>
</Codenesium>*/
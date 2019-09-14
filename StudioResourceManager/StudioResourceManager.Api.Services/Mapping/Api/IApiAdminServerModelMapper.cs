using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>3187398ac752ca390bc5f61d515ec93c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
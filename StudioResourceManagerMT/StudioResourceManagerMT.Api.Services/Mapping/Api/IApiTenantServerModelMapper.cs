using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiTenantServerModelMapper
	{
		ApiTenantServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTenantServerRequestModel request);

		ApiTenantServerRequestModel MapServerResponseToRequest(
			ApiTenantServerResponseModel response);

		ApiTenantClientRequestModel MapServerResponseToClientRequest(
			ApiTenantServerResponseModel response);

		JsonPatchDocument<ApiTenantServerRequestModel> CreatePatch(ApiTenantServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>237bf1c3a9ee9bc0f339a080ada382e0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
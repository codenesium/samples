using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerCapabilityServerModelMapper
	{
		ApiOfficerCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOfficerCapabilityServerRequestModel request);

		ApiOfficerCapabilityServerRequestModel MapServerResponseToRequest(
			ApiOfficerCapabilityServerResponseModel response);

		ApiOfficerCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerCapabilityServerResponseModel response);

		JsonPatchDocument<ApiOfficerCapabilityServerRequestModel> CreatePatch(ApiOfficerCapabilityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>98be9ad3dac572f9534c47bdb5d9c2c4</Hash>
</Codenesium>*/
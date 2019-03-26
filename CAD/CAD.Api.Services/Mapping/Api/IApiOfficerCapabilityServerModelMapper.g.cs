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
			int capabilityId,
			ApiOfficerCapabilityServerRequestModel request);

		ApiOfficerCapabilityServerRequestModel MapServerResponseToRequest(
			ApiOfficerCapabilityServerResponseModel response);

		ApiOfficerCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerCapabilityServerResponseModel response);

		JsonPatchDocument<ApiOfficerCapabilityServerRequestModel> CreatePatch(ApiOfficerCapabilityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3d255632bdf8bad74a23fe3ae7496f56</Hash>
</Codenesium>*/
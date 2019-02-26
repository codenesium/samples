using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerCapabilitiesServerModelMapper
	{
		ApiOfficerCapabilitiesServerResponseModel MapServerRequestToResponse(
			int capabilityId,
			ApiOfficerCapabilitiesServerRequestModel request);

		ApiOfficerCapabilitiesServerRequestModel MapServerResponseToRequest(
			ApiOfficerCapabilitiesServerResponseModel response);

		ApiOfficerCapabilitiesClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerCapabilitiesServerResponseModel response);

		JsonPatchDocument<ApiOfficerCapabilitiesServerRequestModel> CreatePatch(ApiOfficerCapabilitiesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6410bedd5e543d8c996b28ac3845c144</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiStudioServerModelMapper
	{
		ApiStudioServerResponseModel MapServerRequestToResponse(
			int id,
			ApiStudioServerRequestModel request);

		ApiStudioServerRequestModel MapServerResponseToRequest(
			ApiStudioServerResponseModel response);

		ApiStudioClientRequestModel MapServerResponseToClientRequest(
			ApiStudioServerResponseModel response);

		JsonPatchDocument<ApiStudioServerRequestModel> CreatePatch(ApiStudioServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>347e3830257e7a1355bf56e966b0b64c</Hash>
</Codenesium>*/
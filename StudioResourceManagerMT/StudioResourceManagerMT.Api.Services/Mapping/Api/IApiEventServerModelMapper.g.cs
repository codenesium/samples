using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventServerModelMapper
	{
		ApiEventServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventServerRequestModel request);

		ApiEventServerRequestModel MapServerResponseToRequest(
			ApiEventServerResponseModel response);

		ApiEventClientRequestModel MapServerResponseToClientRequest(
			ApiEventServerResponseModel response);

		JsonPatchDocument<ApiEventServerRequestModel> CreatePatch(ApiEventServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>eaf4fc41c51630c089bf4d9b23c6a68b</Hash>
</Codenesium>*/
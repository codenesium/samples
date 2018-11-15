using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiSpaceServerModelMapper
	{
		ApiSpaceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpaceServerRequestModel request);

		ApiSpaceServerRequestModel MapServerResponseToRequest(
			ApiSpaceServerResponseModel response);

		ApiSpaceClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceServerResponseModel response);

		JsonPatchDocument<ApiSpaceServerRequestModel> CreatePatch(ApiSpaceServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e53f1acec0cd2595c91960ef71855d2d</Hash>
</Codenesium>*/
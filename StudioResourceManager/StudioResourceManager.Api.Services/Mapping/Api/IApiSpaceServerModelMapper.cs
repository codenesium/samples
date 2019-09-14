using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>7c99707f11c0ed89b66797baa24647b1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiUserServerModelMapper
	{
		ApiUserServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUserServerRequestModel request);

		ApiUserServerRequestModel MapServerResponseToRequest(
			ApiUserServerResponseModel response);

		ApiUserClientRequestModel MapServerResponseToClientRequest(
			ApiUserServerResponseModel response);

		JsonPatchDocument<ApiUserServerRequestModel> CreatePatch(ApiUserServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b2be936fde746a452459ad416fa30908</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
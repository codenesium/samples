using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>bb984230f09532311dbab134ccfa0c6d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
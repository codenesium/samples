using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventStatusServerModelMapper
	{
		ApiEventStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStatusServerRequestModel request);

		ApiEventStatusServerRequestModel MapServerResponseToRequest(
			ApiEventStatusServerResponseModel response);

		ApiEventStatusClientRequestModel MapServerResponseToClientRequest(
			ApiEventStatusServerResponseModel response);

		JsonPatchDocument<ApiEventStatusServerRequestModel> CreatePatch(ApiEventStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c3dd042780981e118e84b300c3d87d9f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
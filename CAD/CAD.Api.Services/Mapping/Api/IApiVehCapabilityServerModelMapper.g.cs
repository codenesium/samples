using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehCapabilityServerModelMapper
	{
		ApiVehCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehCapabilityServerRequestModel request);

		ApiVehCapabilityServerRequestModel MapServerResponseToRequest(
			ApiVehCapabilityServerResponseModel response);

		ApiVehCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiVehCapabilityServerResponseModel response);

		JsonPatchDocument<ApiVehCapabilityServerRequestModel> CreatePatch(ApiVehCapabilityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>453be0fb790fd6076b85274d37e53750</Hash>
</Codenesium>*/
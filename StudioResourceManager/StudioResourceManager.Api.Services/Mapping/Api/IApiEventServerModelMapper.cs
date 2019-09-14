using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>0e300f821c50f98286c12d79b3cca1e6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using FileServiceNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiFileServerModelMapper
	{
		ApiFileServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFileServerRequestModel request);

		ApiFileServerRequestModel MapServerResponseToRequest(
			ApiFileServerResponseModel response);

		ApiFileClientRequestModel MapServerResponseToClientRequest(
			ApiFileServerResponseModel response);

		JsonPatchDocument<ApiFileServerRequestModel> CreatePatch(ApiFileServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>67e6d28a5acdab042e91818a0c121687</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkServerModelMapper
	{
		ApiLinkServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkServerRequestModel request);

		ApiLinkServerRequestModel MapServerResponseToRequest(
			ApiLinkServerResponseModel response);

		ApiLinkClientRequestModel MapServerResponseToClientRequest(
			ApiLinkServerResponseModel response);

		JsonPatchDocument<ApiLinkServerRequestModel> CreatePatch(ApiLinkServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>dbe6f1d1a7c1d6cf8731418bc929b8fc</Hash>
</Codenesium>*/
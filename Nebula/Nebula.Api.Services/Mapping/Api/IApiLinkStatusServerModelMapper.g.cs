using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkStatusServerModelMapper
	{
		ApiLinkStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkStatusServerRequestModel request);

		ApiLinkStatusServerRequestModel MapServerResponseToRequest(
			ApiLinkStatusServerResponseModel response);

		ApiLinkStatusClientRequestModel MapServerResponseToClientRequest(
			ApiLinkStatusServerResponseModel response);

		JsonPatchDocument<ApiLinkStatusServerRequestModel> CreatePatch(ApiLinkStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c8ee38488238e3aac5dcef06e29a8448</Hash>
</Codenesium>*/
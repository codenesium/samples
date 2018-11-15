using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiMessageServerModelMapper
	{
		ApiMessageServerResponseModel MapServerRequestToResponse(
			int messageId,
			ApiMessageServerRequestModel request);

		ApiMessageServerRequestModel MapServerResponseToRequest(
			ApiMessageServerResponseModel response);

		ApiMessageClientRequestModel MapServerResponseToClientRequest(
			ApiMessageServerResponseModel response);

		JsonPatchDocument<ApiMessageServerRequestModel> CreatePatch(ApiMessageServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>33c6b54e9ab081cb0365fe71eac73925</Hash>
</Codenesium>*/
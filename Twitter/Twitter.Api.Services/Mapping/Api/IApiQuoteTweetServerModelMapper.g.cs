using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiQuoteTweetServerModelMapper
	{
		ApiQuoteTweetServerResponseModel MapServerRequestToResponse(
			int quoteTweetId,
			ApiQuoteTweetServerRequestModel request);

		ApiQuoteTweetServerRequestModel MapServerResponseToRequest(
			ApiQuoteTweetServerResponseModel response);

		ApiQuoteTweetClientRequestModel MapServerResponseToClientRequest(
			ApiQuoteTweetServerResponseModel response);

		JsonPatchDocument<ApiQuoteTweetServerRequestModel> CreatePatch(ApiQuoteTweetServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1fad7d4f42f0ea67487b48adc0abda0e</Hash>
</Codenesium>*/
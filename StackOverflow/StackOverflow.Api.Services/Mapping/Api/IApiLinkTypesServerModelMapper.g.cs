using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiLinkTypesServerModelMapper
	{
		ApiLinkTypesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkTypesServerRequestModel request);

		ApiLinkTypesServerRequestModel MapServerResponseToRequest(
			ApiLinkTypesServerResponseModel response);

		ApiLinkTypesClientRequestModel MapServerResponseToClientRequest(
			ApiLinkTypesServerResponseModel response);

		JsonPatchDocument<ApiLinkTypesServerRequestModel> CreatePatch(ApiLinkTypesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d0732ff21c5fe68ee3b42da7a63ac339</Hash>
</Codenesium>*/
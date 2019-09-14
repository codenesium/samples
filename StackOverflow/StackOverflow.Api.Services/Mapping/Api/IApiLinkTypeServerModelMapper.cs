using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiLinkTypeServerModelMapper
	{
		ApiLinkTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkTypeServerRequestModel request);

		ApiLinkTypeServerRequestModel MapServerResponseToRequest(
			ApiLinkTypeServerResponseModel response);

		ApiLinkTypeClientRequestModel MapServerResponseToClientRequest(
			ApiLinkTypeServerResponseModel response);

		JsonPatchDocument<ApiLinkTypeServerRequestModel> CreatePatch(ApiLinkTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0daeda6cb989bceceaca431a31ffe0a2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
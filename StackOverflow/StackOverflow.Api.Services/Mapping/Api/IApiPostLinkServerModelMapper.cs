using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostLinkServerModelMapper
	{
		ApiPostLinkServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostLinkServerRequestModel request);

		ApiPostLinkServerRequestModel MapServerResponseToRequest(
			ApiPostLinkServerResponseModel response);

		ApiPostLinkClientRequestModel MapServerResponseToClientRequest(
			ApiPostLinkServerResponseModel response);

		JsonPatchDocument<ApiPostLinkServerRequestModel> CreatePatch(ApiPostLinkServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0e37fb234252f516fea3fbcc6f7887e5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostHistoryTypeServerModelMapper
	{
		ApiPostHistoryTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostHistoryTypeServerRequestModel request);

		ApiPostHistoryTypeServerRequestModel MapServerResponseToRequest(
			ApiPostHistoryTypeServerResponseModel response);

		ApiPostHistoryTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPostHistoryTypeServerResponseModel response);

		JsonPatchDocument<ApiPostHistoryTypeServerRequestModel> CreatePatch(ApiPostHistoryTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5fb07ea3827a459c70252188f18dc56e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostHistoryServerModelMapper
	{
		ApiPostHistoryServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostHistoryServerRequestModel request);

		ApiPostHistoryServerRequestModel MapServerResponseToRequest(
			ApiPostHistoryServerResponseModel response);

		ApiPostHistoryClientRequestModel MapServerResponseToClientRequest(
			ApiPostHistoryServerResponseModel response);

		JsonPatchDocument<ApiPostHistoryServerRequestModel> CreatePatch(ApiPostHistoryServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>589ef1f723a4347b8dc9058b22c7aecc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
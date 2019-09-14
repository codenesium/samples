using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiUserServerModelMapper
	{
		ApiUserServerResponseModel MapServerRequestToResponse(
			int userId,
			ApiUserServerRequestModel request);

		ApiUserServerRequestModel MapServerResponseToRequest(
			ApiUserServerResponseModel response);

		ApiUserClientRequestModel MapServerResponseToClientRequest(
			ApiUserServerResponseModel response);

		JsonPatchDocument<ApiUserServerRequestModel> CreatePatch(ApiUserServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a92cf79b7987fbfcadb973f67e480aa9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
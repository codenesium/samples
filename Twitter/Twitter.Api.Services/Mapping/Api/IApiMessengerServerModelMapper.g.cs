using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiMessengerServerModelMapper
	{
		ApiMessengerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiMessengerServerRequestModel request);

		ApiMessengerServerRequestModel MapServerResponseToRequest(
			ApiMessengerServerResponseModel response);

		ApiMessengerClientRequestModel MapServerResponseToClientRequest(
			ApiMessengerServerResponseModel response);

		JsonPatchDocument<ApiMessengerServerRequestModel> CreatePatch(ApiMessengerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ec90a441998589811d6700ec2ee6877d</Hash>
</Codenesium>*/
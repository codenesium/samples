using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiPersonServerModelMapper
	{
		ApiPersonServerResponseModel MapServerRequestToResponse(
			int personId,
			ApiPersonServerRequestModel request);

		ApiPersonServerRequestModel MapServerResponseToRequest(
			ApiPersonServerResponseModel response);

		ApiPersonClientRequestModel MapServerResponseToClientRequest(
			ApiPersonServerResponseModel response);

		JsonPatchDocument<ApiPersonServerRequestModel> CreatePatch(ApiPersonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f75d9bd7b4325689d7328dd663e88440</Hash>
</Codenesium>*/
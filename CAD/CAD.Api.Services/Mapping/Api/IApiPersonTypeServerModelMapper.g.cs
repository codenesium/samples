using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiPersonTypeServerModelMapper
	{
		ApiPersonTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPersonTypeServerRequestModel request);

		ApiPersonTypeServerRequestModel MapServerResponseToRequest(
			ApiPersonTypeServerResponseModel response);

		ApiPersonTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPersonTypeServerResponseModel response);

		JsonPatchDocument<ApiPersonTypeServerRequestModel> CreatePatch(ApiPersonTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>74240e2aef07912d9ce3f391e1be86ac</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPersonServerModelMapper
	{
		ApiPersonServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiPersonServerRequestModel request);

		ApiPersonServerRequestModel MapServerResponseToRequest(
			ApiPersonServerResponseModel response);

		ApiPersonClientRequestModel MapServerResponseToClientRequest(
			ApiPersonServerResponseModel response);

		JsonPatchDocument<ApiPersonServerRequestModel> CreatePatch(ApiPersonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>964b942de0bf4e3e5764573d8977470e</Hash>
</Codenesium>*/
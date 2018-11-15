using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiTableServerModelMapper
	{
		ApiTableServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTableServerRequestModel request);

		ApiTableServerRequestModel MapServerResponseToRequest(
			ApiTableServerResponseModel response);

		ApiTableClientRequestModel MapServerResponseToClientRequest(
			ApiTableServerResponseModel response);

		JsonPatchDocument<ApiTableServerRequestModel> CreatePatch(ApiTableServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c28833866fa430b08d8a51d1db6335b2</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiStoreServerModelMapper
	{
		ApiStoreServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiStoreServerRequestModel request);

		ApiStoreServerRequestModel MapServerResponseToRequest(
			ApiStoreServerResponseModel response);

		ApiStoreClientRequestModel MapServerResponseToClientRequest(
			ApiStoreServerResponseModel response);

		JsonPatchDocument<ApiStoreServerRequestModel> CreatePatch(ApiStoreServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>02b52945c58efb2c3dc8725d76411492</Hash>
</Codenesium>*/
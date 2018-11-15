using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiCompositePrimaryKeyServerModelMapper
	{
		ApiCompositePrimaryKeyServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCompositePrimaryKeyServerRequestModel request);

		ApiCompositePrimaryKeyServerRequestModel MapServerResponseToRequest(
			ApiCompositePrimaryKeyServerResponseModel response);

		ApiCompositePrimaryKeyClientRequestModel MapServerResponseToClientRequest(
			ApiCompositePrimaryKeyServerResponseModel response);

		JsonPatchDocument<ApiCompositePrimaryKeyServerRequestModel> CreatePatch(ApiCompositePrimaryKeyServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>72750b6722f92048f6f5d36935854bd3</Hash>
</Codenesium>*/
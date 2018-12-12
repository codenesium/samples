using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IApiEfmigrationshistoryServerModelMapper
	{
		ApiEfmigrationshistoryServerResponseModel MapServerRequestToResponse(
			string migrationId,
			ApiEfmigrationshistoryServerRequestModel request);

		ApiEfmigrationshistoryServerRequestModel MapServerResponseToRequest(
			ApiEfmigrationshistoryServerResponseModel response);

		ApiEfmigrationshistoryClientRequestModel MapServerResponseToClientRequest(
			ApiEfmigrationshistoryServerResponseModel response);

		JsonPatchDocument<ApiEfmigrationshistoryServerRequestModel> CreatePatch(ApiEfmigrationshistoryServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2471c694fe06e03eeb8fbe6d01ef018b</Hash>
</Codenesium>*/
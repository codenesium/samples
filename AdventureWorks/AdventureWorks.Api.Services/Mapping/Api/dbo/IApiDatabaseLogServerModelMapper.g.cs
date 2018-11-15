using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDatabaseLogServerModelMapper
	{
		ApiDatabaseLogServerResponseModel MapServerRequestToResponse(
			int databaseLogID,
			ApiDatabaseLogServerRequestModel request);

		ApiDatabaseLogServerRequestModel MapServerResponseToRequest(
			ApiDatabaseLogServerResponseModel response);

		ApiDatabaseLogClientRequestModel MapServerResponseToClientRequest(
			ApiDatabaseLogServerResponseModel response);

		JsonPatchDocument<ApiDatabaseLogServerRequestModel> CreatePatch(ApiDatabaseLogServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>99ab4e5672deba11b6fe4b3bc1478248</Hash>
</Codenesium>*/
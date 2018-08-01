using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiDatabaseLogModelMapper
	{
		ApiDatabaseLogResponseModel MapRequestToResponse(
			int databaseLogID,
			ApiDatabaseLogRequestModel request);

		ApiDatabaseLogRequestModel MapResponseToRequest(
			ApiDatabaseLogResponseModel response);

		JsonPatchDocument<ApiDatabaseLogRequestModel> CreatePatch(ApiDatabaseLogRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b46dfb9612dfb28f146d5009d6cbd6c2</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiDatabaseLogModelMapper
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
    <Hash>bf6bbab38371eb6634bcc283452d1f94</Hash>
</Codenesium>*/
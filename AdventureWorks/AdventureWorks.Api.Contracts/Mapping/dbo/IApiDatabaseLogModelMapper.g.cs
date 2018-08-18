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
    <Hash>32ef9cf0b5ef529c5a7b26a7b89f741a</Hash>
</Codenesium>*/
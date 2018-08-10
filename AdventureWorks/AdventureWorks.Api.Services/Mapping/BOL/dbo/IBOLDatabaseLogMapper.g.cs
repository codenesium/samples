using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLDatabaseLogMapper
	{
		BODatabaseLog MapModelToBO(
			int databaseLogID,
			ApiDatabaseLogRequestModel model);

		ApiDatabaseLogResponseModel MapBOToModel(
			BODatabaseLog boDatabaseLog);

		List<ApiDatabaseLogResponseModel> MapBOToModel(
			List<BODatabaseLog> items);
	}
}

/*<Codenesium>
    <Hash>c4c7df309fa065e702b5ff76ad979e4b</Hash>
</Codenesium>*/
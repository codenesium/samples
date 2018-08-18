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
    <Hash>0309ff19b6160e388901056c55350b50</Hash>
</Codenesium>*/
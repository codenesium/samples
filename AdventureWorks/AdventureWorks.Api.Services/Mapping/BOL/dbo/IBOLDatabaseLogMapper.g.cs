using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLDatabaseLogMapper
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
    <Hash>fc4d7bd4e6bf27342c59e4780e57c12b</Hash>
</Codenesium>*/
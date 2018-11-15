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
			ApiDatabaseLogServerRequestModel model);

		ApiDatabaseLogServerResponseModel MapBOToModel(
			BODatabaseLog boDatabaseLog);

		List<ApiDatabaseLogServerResponseModel> MapBOToModel(
			List<BODatabaseLog> items);
	}
}

/*<Codenesium>
    <Hash>8acb8a8dfc778667bd9dd473a61707ef</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDatabaseLogMapper
	{
		DatabaseLog MapModelToBO(
			int databaseLogID,
			ApiDatabaseLogServerRequestModel model);

		ApiDatabaseLogServerResponseModel MapBOToModel(
			DatabaseLog item);

		List<ApiDatabaseLogServerResponseModel> MapBOToModel(
			List<DatabaseLog> items);
	}
}

/*<Codenesium>
    <Hash>acce92bb2f8f01e0ecbbe71cb1e42cc5</Hash>
</Codenesium>*/
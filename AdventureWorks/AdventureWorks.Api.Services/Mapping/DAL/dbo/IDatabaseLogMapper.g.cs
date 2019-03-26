using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDatabaseLogMapper
	{
		DatabaseLog MapModelToEntity(
			int databaseLogID,
			ApiDatabaseLogServerRequestModel model);

		ApiDatabaseLogServerResponseModel MapEntityToModel(
			DatabaseLog item);

		List<ApiDatabaseLogServerResponseModel> MapEntityToModel(
			List<DatabaseLog> items);
	}
}

/*<Codenesium>
    <Hash>c34baa9631ee8f50c1fd020080d05733</Hash>
</Codenesium>*/
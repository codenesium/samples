using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
			List<BODatabaseLog> bos);
	}
}

/*<Codenesium>
    <Hash>fe096ec3c887a6aaa6790e30978f0057</Hash>
</Codenesium>*/
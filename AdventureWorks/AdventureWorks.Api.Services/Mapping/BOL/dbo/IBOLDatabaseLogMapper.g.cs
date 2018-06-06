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
			List<BODatabaseLog> items);
	}
}

/*<Codenesium>
    <Hash>5e1f6f938c74ac513f351b85d4a2af11</Hash>
</Codenesium>*/
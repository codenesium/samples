using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLDatabaseLogMapper
	{
		DTODatabaseLog MapModelToDTO(
			int databaseLogID,
			ApiDatabaseLogRequestModel model);

		ApiDatabaseLogResponseModel MapDTOToModel(
			DTODatabaseLog dtoDatabaseLog);

		List<ApiDatabaseLogResponseModel> MapDTOToModel(
			List<DTODatabaseLog> dtos);
	}
}

/*<Codenesium>
    <Hash>2f3bab26c1818d1db254e3969a28c399</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLDatabaseLogMapper
	{
		public virtual DTODatabaseLog MapModelToDTO(
			int databaseLogID,
			ApiDatabaseLogRequestModel model
			)
		{
			DTODatabaseLog dtoDatabaseLog = new DTODatabaseLog();

			dtoDatabaseLog.SetProperties(
				databaseLogID,
				model.DatabaseUser,
				model.@Event,
				model.@Object,
				model.PostTime,
				model.Schema,
				model.TSQL,
				model.XmlEvent);
			return dtoDatabaseLog;
		}

		public virtual ApiDatabaseLogResponseModel MapDTOToModel(
			DTODatabaseLog dtoDatabaseLog)
		{
			if (dtoDatabaseLog == null)
			{
				return null;
			}

			var model = new ApiDatabaseLogResponseModel();

			model.SetProperties(dtoDatabaseLog.DatabaseLogID, dtoDatabaseLog.DatabaseUser, dtoDatabaseLog.@Event, dtoDatabaseLog.@Object, dtoDatabaseLog.PostTime, dtoDatabaseLog.Schema, dtoDatabaseLog.TSQL, dtoDatabaseLog.XmlEvent);

			return model;
		}

		public virtual List<ApiDatabaseLogResponseModel> MapDTOToModel(
			List<DTODatabaseLog> dtos)
		{
			List<ApiDatabaseLogResponseModel> response = new List<ApiDatabaseLogResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6956ce976e72604d37d1fefc8b492e2b</Hash>
</Codenesium>*/
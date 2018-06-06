using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractDatabaseLogMapper
	{
		public virtual BODatabaseLog MapModelToBO(
			int databaseLogID,
			ApiDatabaseLogRequestModel model
			)
		{
			BODatabaseLog boDatabaseLog = new BODatabaseLog();

			boDatabaseLog.SetProperties(
				databaseLogID,
				model.DatabaseUser,
				model.@Event,
				model.@Object,
				model.PostTime,
				model.Schema,
				model.TSQL,
				model.XmlEvent);
			return boDatabaseLog;
		}

		public virtual ApiDatabaseLogResponseModel MapBOToModel(
			BODatabaseLog boDatabaseLog)
		{
			var model = new ApiDatabaseLogResponseModel();

			model.SetProperties(boDatabaseLog.DatabaseLogID, boDatabaseLog.DatabaseUser, boDatabaseLog.@Event, boDatabaseLog.@Object, boDatabaseLog.PostTime, boDatabaseLog.Schema, boDatabaseLog.TSQL, boDatabaseLog.XmlEvent);

			return model;
		}

		public virtual List<ApiDatabaseLogResponseModel> MapBOToModel(
			List<BODatabaseLog> items)
		{
			List<ApiDatabaseLogResponseModel> response = new List<ApiDatabaseLogResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c3d2038c08f5f13fa2e8b4d001bfa6e6</Hash>
</Codenesium>*/
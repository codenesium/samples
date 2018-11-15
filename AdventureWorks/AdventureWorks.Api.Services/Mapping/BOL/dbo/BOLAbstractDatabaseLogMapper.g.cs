using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractDatabaseLogMapper
	{
		public virtual BODatabaseLog MapModelToBO(
			int databaseLogID,
			ApiDatabaseLogServerRequestModel model
			)
		{
			BODatabaseLog boDatabaseLog = new BODatabaseLog();
			boDatabaseLog.SetProperties(
				databaseLogID,
				model.@Event,
				model.@Object,
				model.DatabaseUser,
				model.PostTime,
				model.Schema,
				model.Tsql,
				model.XmlEvent);
			return boDatabaseLog;
		}

		public virtual ApiDatabaseLogServerResponseModel MapBOToModel(
			BODatabaseLog boDatabaseLog)
		{
			var model = new ApiDatabaseLogServerResponseModel();

			model.SetProperties(boDatabaseLog.DatabaseLogID, boDatabaseLog.@Event, boDatabaseLog.@Object, boDatabaseLog.DatabaseUser, boDatabaseLog.PostTime, boDatabaseLog.Schema, boDatabaseLog.Tsql, boDatabaseLog.XmlEvent);

			return model;
		}

		public virtual List<ApiDatabaseLogServerResponseModel> MapBOToModel(
			List<BODatabaseLog> items)
		{
			List<ApiDatabaseLogServerResponseModel> response = new List<ApiDatabaseLogServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bead9d7d028b623c28c7d5ed496f1b6a</Hash>
</Codenesium>*/
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
			BODatabaseLog BODatabaseLog = new BODatabaseLog();

			BODatabaseLog.SetProperties(
				databaseLogID,
				model.DatabaseUser,
				model.@Event,
				model.@Object,
				model.PostTime,
				model.Schema,
				model.TSQL,
				model.XmlEvent);
			return BODatabaseLog;
		}

		public virtual ApiDatabaseLogResponseModel MapBOToModel(
			BODatabaseLog BODatabaseLog)
		{
			if (BODatabaseLog == null)
			{
				return null;
			}

			var model = new ApiDatabaseLogResponseModel();

			model.SetProperties(BODatabaseLog.DatabaseLogID, BODatabaseLog.DatabaseUser, BODatabaseLog.@Event, BODatabaseLog.@Object, BODatabaseLog.PostTime, BODatabaseLog.Schema, BODatabaseLog.TSQL, BODatabaseLog.XmlEvent);

			return model;
		}

		public virtual List<ApiDatabaseLogResponseModel> MapBOToModel(
			List<BODatabaseLog> BOs)
		{
			List<ApiDatabaseLogResponseModel> response = new List<ApiDatabaseLogResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4d147af354107f953bbe005dc1bff41e</Hash>
</Codenesium>*/
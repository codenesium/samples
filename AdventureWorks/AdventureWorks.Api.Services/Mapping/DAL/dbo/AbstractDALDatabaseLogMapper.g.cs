using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALDatabaseLogMapper
	{
		public virtual DatabaseLog MapModelToBO(
			int databaseLogID,
			ApiDatabaseLogServerRequestModel model
			)
		{
			DatabaseLog item = new DatabaseLog();
			item.SetProperties(
				databaseLogID,
				model.DatabaseUser,
				model.PostTime,
				model.Schema,
				model.Tsql,
				model.XmlEvent);
			return item;
		}

		public virtual ApiDatabaseLogServerResponseModel MapBOToModel(
			DatabaseLog item)
		{
			var model = new ApiDatabaseLogServerResponseModel();

			model.SetProperties(item.DatabaseLogID, item.DatabaseUser, item.PostTime, item.Schema, item.Tsql, item.XmlEvent);

			return model;
		}

		public virtual List<ApiDatabaseLogServerResponseModel> MapBOToModel(
			List<DatabaseLog> items)
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
    <Hash>493c7409e874ad2bd63bc1b37424e06f</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALDatabaseLogMapper
	{
		public virtual DatabaseLog MapModelToEntity(
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

		public virtual ApiDatabaseLogServerResponseModel MapEntityToModel(
			DatabaseLog item)
		{
			var model = new ApiDatabaseLogServerResponseModel();

			model.SetProperties(item.DatabaseLogID,
			                    item.DatabaseUser,
			                    item.PostTime,
			                    item.Schema,
			                    item.Tsql,
			                    item.XmlEvent);

			return model;
		}

		public virtual List<ApiDatabaseLogServerResponseModel> MapEntityToModel(
			List<DatabaseLog> items)
		{
			List<ApiDatabaseLogServerResponseModel> response = new List<ApiDatabaseLogServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>01a6aea752eac7918bec83b123de8548</Hash>
</Codenesium>*/
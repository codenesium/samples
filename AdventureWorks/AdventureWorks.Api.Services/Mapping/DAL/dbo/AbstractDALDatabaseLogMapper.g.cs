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
				model.ReservedEvent,
				model.ReservedObject,
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
			                    item.ReservedEvent,
			                    item.ReservedObject,
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
    <Hash>6f6641e41c30e4c4ff602c65bd0a4cba</Hash>
</Codenesium>*/
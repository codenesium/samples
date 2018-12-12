using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public abstract class BOLAbstractEfmigrationshistoryMapper
	{
		public virtual BOEfmigrationshistory MapModelToBO(
			string migrationId,
			ApiEfmigrationshistoryServerRequestModel model
			)
		{
			BOEfmigrationshistory boEfmigrationshistory = new BOEfmigrationshistory();
			boEfmigrationshistory.SetProperties(
				migrationId,
				model.ProductVersion);
			return boEfmigrationshistory;
		}

		public virtual ApiEfmigrationshistoryServerResponseModel MapBOToModel(
			BOEfmigrationshistory boEfmigrationshistory)
		{
			var model = new ApiEfmigrationshistoryServerResponseModel();

			model.SetProperties(boEfmigrationshistory.MigrationId, boEfmigrationshistory.ProductVersion);

			return model;
		}

		public virtual List<ApiEfmigrationshistoryServerResponseModel> MapBOToModel(
			List<BOEfmigrationshistory> items)
		{
			List<ApiEfmigrationshistoryServerResponseModel> response = new List<ApiEfmigrationshistoryServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>350107a545a11580ff201ae0c8175518</Hash>
</Codenesium>*/
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractSchemaVersionsMapper
	{
		public virtual BOSchemaVersions MapModelToBO(
			int id,
			ApiSchemaVersionsRequestModel model
			)
		{
			BOSchemaVersions boSchemaVersions = new BOSchemaVersions();
			boSchemaVersions.SetProperties(
				id,
				model.Applied,
				model.ScriptName);
			return boSchemaVersions;
		}

		public virtual ApiSchemaVersionsResponseModel MapBOToModel(
			BOSchemaVersions boSchemaVersions)
		{
			var model = new ApiSchemaVersionsResponseModel();

			model.SetProperties(boSchemaVersions.Id, boSchemaVersions.Applied, boSchemaVersions.ScriptName);

			return model;
		}

		public virtual List<ApiSchemaVersionsResponseModel> MapBOToModel(
			List<BOSchemaVersions> items)
		{
			List<ApiSchemaVersionsResponseModel> response = new List<ApiSchemaVersionsResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cb83d5e5894fdd68bc4015fdc80c9c9d</Hash>
</Codenesium>*/
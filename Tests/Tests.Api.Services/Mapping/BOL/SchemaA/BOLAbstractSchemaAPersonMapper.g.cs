using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractSchemaAPersonMapper
	{
		public virtual BOSchemaAPerson MapModelToBO(
			int id,
			ApiSchemaAPersonServerRequestModel model
			)
		{
			BOSchemaAPerson boSchemaAPerson = new BOSchemaAPerson();
			boSchemaAPerson.SetProperties(
				id,
				model.Name);
			return boSchemaAPerson;
		}

		public virtual ApiSchemaAPersonServerResponseModel MapBOToModel(
			BOSchemaAPerson boSchemaAPerson)
		{
			var model = new ApiSchemaAPersonServerResponseModel();

			model.SetProperties(boSchemaAPerson.Id, boSchemaAPerson.Name);

			return model;
		}

		public virtual List<ApiSchemaAPersonServerResponseModel> MapBOToModel(
			List<BOSchemaAPerson> items)
		{
			List<ApiSchemaAPersonServerResponseModel> response = new List<ApiSchemaAPersonServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ded5855c1d31fa6ee0f36e8a64f01e1a</Hash>
</Codenesium>*/
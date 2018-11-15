using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractSchemaBPersonMapper
	{
		public virtual BOSchemaBPerson MapModelToBO(
			int id,
			ApiSchemaBPersonServerRequestModel model
			)
		{
			BOSchemaBPerson boSchemaBPerson = new BOSchemaBPerson();
			boSchemaBPerson.SetProperties(
				id,
				model.Name);
			return boSchemaBPerson;
		}

		public virtual ApiSchemaBPersonServerResponseModel MapBOToModel(
			BOSchemaBPerson boSchemaBPerson)
		{
			var model = new ApiSchemaBPersonServerResponseModel();

			model.SetProperties(boSchemaBPerson.Id, boSchemaBPerson.Name);

			return model;
		}

		public virtual List<ApiSchemaBPersonServerResponseModel> MapBOToModel(
			List<BOSchemaBPerson> items)
		{
			List<ApiSchemaBPersonServerResponseModel> response = new List<ApiSchemaBPersonServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>41fab0ac2c19d56b7ae1bc7d7cc4be1b</Hash>
</Codenesium>*/
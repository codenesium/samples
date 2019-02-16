using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractDALPersonMapper
	{
		public virtual Person MapModelToEntity(
			int personId,
			ApiPersonServerRequestModel model
			)
		{
			Person item = new Person();
			item.SetProperties(
				personId,
				model.PersonName);
			return item;
		}

		public virtual ApiPersonServerResponseModel MapEntityToModel(
			Person item)
		{
			var model = new ApiPersonServerResponseModel();

			model.SetProperties(item.PersonId,
			                    item.PersonName);

			return model;
		}

		public virtual List<ApiPersonServerResponseModel> MapEntityToModel(
			List<Person> items)
		{
			List<ApiPersonServerResponseModel> response = new List<ApiPersonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>04decf6d9f2a489948c4c3d809c700ed</Hash>
</Codenesium>*/
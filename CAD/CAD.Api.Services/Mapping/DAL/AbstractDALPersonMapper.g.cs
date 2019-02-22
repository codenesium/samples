using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALPersonMapper
	{
		public virtual Person MapModelToEntity(
			int id,
			ApiPersonServerRequestModel model
			)
		{
			Person item = new Person();
			item.SetProperties(
				id,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.Ssn);
			return item;
		}

		public virtual ApiPersonServerResponseModel MapEntityToModel(
			Person item)
		{
			var model = new ApiPersonServerResponseModel();

			model.SetProperties(item.Id,
			                    item.FirstName,
			                    item.LastName,
			                    item.Phone,
			                    item.Ssn);

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
    <Hash>119bbc83e047dda8f336cdb0dfa04fd2</Hash>
</Codenesium>*/
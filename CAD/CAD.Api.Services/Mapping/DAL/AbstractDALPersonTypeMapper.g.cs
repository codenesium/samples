using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALPersonTypeMapper
	{
		public virtual PersonType MapModelToEntity(
			int id,
			ApiPersonTypeServerRequestModel model
			)
		{
			PersonType item = new PersonType();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiPersonTypeServerResponseModel MapEntityToModel(
			PersonType item)
		{
			var model = new ApiPersonTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPersonTypeServerResponseModel> MapEntityToModel(
			List<PersonType> items)
		{
			List<ApiPersonTypeServerResponseModel> response = new List<ApiPersonTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5e6e1617d727ec03fdce42a5655579cf</Hash>
</Codenesium>*/
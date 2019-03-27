using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PointOfSaleNS.Api.Services
{
	public abstract class AbstractDALProductMapper
	{
		public virtual Product MapModelToEntity(
			int id,
			ApiProductServerRequestModel model
			)
		{
			Product item = new Product();
			item.SetProperties(
				id,
				model.Active,
				model.Description,
				model.Name,
				model.Price,
				model.Quantity);
			return item;
		}

		public virtual ApiProductServerResponseModel MapEntityToModel(
			Product item)
		{
			var model = new ApiProductServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Active,
			                    item.Description,
			                    item.Name,
			                    item.Price,
			                    item.Quantity);

			return model;
		}

		public virtual List<ApiProductServerResponseModel> MapEntityToModel(
			List<Product> items)
		{
			List<ApiProductServerResponseModel> response = new List<ApiProductServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cd0077dddfac72577cf163eb745f4f77</Hash>
</Codenesium>*/
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PointOfSaleNS.Api.Services
{
	public class DALProductMapper : IDALProductMapper
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
    <Hash>10c0eccf2f2e5f24832c6cd836512fe0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductModelMapper
	{
		public virtual ProductModel MapModelToEntity(
			int productModelID,
			ApiProductModelServerRequestModel model
			)
		{
			ProductModel item = new ProductModel();
			item.SetProperties(
				productModelID,
				model.CatalogDescription,
				model.Instruction,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return item;
		}

		public virtual ApiProductModelServerResponseModel MapEntityToModel(
			ProductModel item)
		{
			var model = new ApiProductModelServerResponseModel();

			model.SetProperties(item.ProductModelID,
			                    item.CatalogDescription,
			                    item.Instruction,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.Rowguid);

			return model;
		}

		public virtual List<ApiProductModelServerResponseModel> MapEntityToModel(
			List<ProductModel> items)
		{
			List<ApiProductModelServerResponseModel> response = new List<ApiProductModelServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3919a0f15ef0f096fa4705e9d991b831</Hash>
</Codenesium>*/
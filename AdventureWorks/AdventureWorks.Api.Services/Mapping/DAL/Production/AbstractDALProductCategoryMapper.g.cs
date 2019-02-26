using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductCategoryMapper
	{
		public virtual ProductCategory MapModelToEntity(
			int productCategoryID,
			ApiProductCategoryServerRequestModel model
			)
		{
			ProductCategory item = new ProductCategory();
			item.SetProperties(
				productCategoryID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return item;
		}

		public virtual ApiProductCategoryServerResponseModel MapEntityToModel(
			ProductCategory item)
		{
			var model = new ApiProductCategoryServerResponseModel();

			model.SetProperties(item.ProductCategoryID,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.Rowguid);

			return model;
		}

		public virtual List<ApiProductCategoryServerResponseModel> MapEntityToModel(
			List<ProductCategory> items)
		{
			List<ApiProductCategoryServerResponseModel> response = new List<ApiProductCategoryServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>14ab06f54b90b19abb72c2070adf1667</Hash>
</Codenesium>*/
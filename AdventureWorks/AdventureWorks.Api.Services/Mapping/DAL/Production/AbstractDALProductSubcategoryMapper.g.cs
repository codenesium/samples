using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductSubcategoryMapper
	{
		public virtual ProductSubcategory MapModelToEntity(
			int productSubcategoryID,
			ApiProductSubcategoryServerRequestModel model
			)
		{
			ProductSubcategory item = new ProductSubcategory();
			item.SetProperties(
				productSubcategoryID,
				model.ModifiedDate,
				model.Name,
				model.ProductCategoryID,
				model.Rowguid);
			return item;
		}

		public virtual ApiProductSubcategoryServerResponseModel MapEntityToModel(
			ProductSubcategory item)
		{
			var model = new ApiProductSubcategoryServerResponseModel();

			model.SetProperties(item.ProductSubcategoryID,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.ProductCategoryID,
			                    item.Rowguid);
			if (item.ProductCategoryIDNavigation != null)
			{
				var productCategoryIDModel = new ApiProductCategoryServerResponseModel();
				productCategoryIDModel.SetProperties(
					item.ProductCategoryIDNavigation.ProductCategoryID,
					item.ProductCategoryIDNavigation.ModifiedDate,
					item.ProductCategoryIDNavigation.Name,
					item.ProductCategoryIDNavigation.Rowguid);

				model.SetProductCategoryIDNavigation(productCategoryIDModel);
			}

			return model;
		}

		public virtual List<ApiProductSubcategoryServerResponseModel> MapEntityToModel(
			List<ProductSubcategory> items)
		{
			List<ApiProductSubcategoryServerResponseModel> response = new List<ApiProductSubcategoryServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aa123c5b0faaa653e7615a26bce720fa</Hash>
</Codenesium>*/
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
    <Hash>120499a6dbcbf415176204bb88c5e27c</Hash>
</Codenesium>*/
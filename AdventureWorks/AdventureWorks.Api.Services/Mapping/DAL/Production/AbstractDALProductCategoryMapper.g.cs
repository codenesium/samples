using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductCategoryMapper
	{
		public virtual ProductCategory MapModelToBO(
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

		public virtual ApiProductCategoryServerResponseModel MapBOToModel(
			ProductCategory item)
		{
			var model = new ApiProductCategoryServerResponseModel();

			model.SetProperties(item.ProductCategoryID, item.ModifiedDate, item.Name, item.Rowguid);

			return model;
		}

		public virtual List<ApiProductCategoryServerResponseModel> MapBOToModel(
			List<ProductCategory> items)
		{
			List<ApiProductCategoryServerResponseModel> response = new List<ApiProductCategoryServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f5ad637027df0875d889ee8b9ab852ac</Hash>
</Codenesium>*/
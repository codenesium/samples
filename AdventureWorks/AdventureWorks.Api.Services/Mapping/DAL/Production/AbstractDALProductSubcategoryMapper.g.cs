using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductSubcategoryMapper
	{
		public virtual ProductSubcategory MapModelToBO(
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

		public virtual ApiProductSubcategoryServerResponseModel MapBOToModel(
			ProductSubcategory item)
		{
			var model = new ApiProductSubcategoryServerResponseModel();

			model.SetProperties(item.ProductSubcategoryID, item.ModifiedDate, item.Name, item.ProductCategoryID, item.Rowguid);

			return model;
		}

		public virtual List<ApiProductSubcategoryServerResponseModel> MapBOToModel(
			List<ProductSubcategory> items)
		{
			List<ApiProductSubcategoryServerResponseModel> response = new List<ApiProductSubcategoryServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>598685cdf8abfa1bd27e884c082018db</Hash>
</Codenesium>*/
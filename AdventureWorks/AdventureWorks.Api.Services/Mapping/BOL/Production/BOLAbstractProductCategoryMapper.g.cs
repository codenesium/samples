using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductCategoryMapper
	{
		public virtual BOProductCategory MapModelToBO(
			int productCategoryID,
			ApiProductCategoryServerRequestModel model
			)
		{
			BOProductCategory boProductCategory = new BOProductCategory();
			boProductCategory.SetProperties(
				productCategoryID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return boProductCategory;
		}

		public virtual ApiProductCategoryServerResponseModel MapBOToModel(
			BOProductCategory boProductCategory)
		{
			var model = new ApiProductCategoryServerResponseModel();

			model.SetProperties(boProductCategory.ProductCategoryID, boProductCategory.ModifiedDate, boProductCategory.Name, boProductCategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductCategoryServerResponseModel> MapBOToModel(
			List<BOProductCategory> items)
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
    <Hash>148f45ca800fd308af834dff4c436a11</Hash>
</Codenesium>*/
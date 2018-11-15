using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductSubcategoryMapper
	{
		public virtual BOProductSubcategory MapModelToBO(
			int productSubcategoryID,
			ApiProductSubcategoryServerRequestModel model
			)
		{
			BOProductSubcategory boProductSubcategory = new BOProductSubcategory();
			boProductSubcategory.SetProperties(
				productSubcategoryID,
				model.ModifiedDate,
				model.Name,
				model.ProductCategoryID,
				model.Rowguid);
			return boProductSubcategory;
		}

		public virtual ApiProductSubcategoryServerResponseModel MapBOToModel(
			BOProductSubcategory boProductSubcategory)
		{
			var model = new ApiProductSubcategoryServerResponseModel();

			model.SetProperties(boProductSubcategory.ProductSubcategoryID, boProductSubcategory.ModifiedDate, boProductSubcategory.Name, boProductSubcategory.ProductCategoryID, boProductSubcategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductSubcategoryServerResponseModel> MapBOToModel(
			List<BOProductSubcategory> items)
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
    <Hash>b2b65193c7542d231483b7b407d351d5</Hash>
</Codenesium>*/
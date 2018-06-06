using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductSubcategoryMapper
	{
		public virtual BOProductSubcategory MapModelToBO(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel model
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

		public virtual ApiProductSubcategoryResponseModel MapBOToModel(
			BOProductSubcategory boProductSubcategory)
		{
			var model = new ApiProductSubcategoryResponseModel();

			model.SetProperties(boProductSubcategory.ModifiedDate, boProductSubcategory.Name, boProductSubcategory.ProductCategoryID, boProductSubcategory.ProductSubcategoryID, boProductSubcategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductSubcategoryResponseModel> MapBOToModel(
			List<BOProductSubcategory> items)
		{
			List<ApiProductSubcategoryResponseModel> response = new List<ApiProductSubcategoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ae0271e91e0f9247a287295952bce7a2</Hash>
</Codenesium>*/
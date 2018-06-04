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
			BOProductSubcategory BOProductSubcategory = new BOProductSubcategory();

			BOProductSubcategory.SetProperties(
				productSubcategoryID,
				model.ModifiedDate,
				model.Name,
				model.ProductCategoryID,
				model.Rowguid);
			return BOProductSubcategory;
		}

		public virtual ApiProductSubcategoryResponseModel MapBOToModel(
			BOProductSubcategory BOProductSubcategory)
		{
			if (BOProductSubcategory == null)
			{
				return null;
			}

			var model = new ApiProductSubcategoryResponseModel();

			model.SetProperties(BOProductSubcategory.ModifiedDate, BOProductSubcategory.Name, BOProductSubcategory.ProductCategoryID, BOProductSubcategory.ProductSubcategoryID, BOProductSubcategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductSubcategoryResponseModel> MapBOToModel(
			List<BOProductSubcategory> BOs)
		{
			List<ApiProductSubcategoryResponseModel> response = new List<ApiProductSubcategoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6ad867892c7f4d6f37776c8a3164b5b3</Hash>
</Codenesium>*/
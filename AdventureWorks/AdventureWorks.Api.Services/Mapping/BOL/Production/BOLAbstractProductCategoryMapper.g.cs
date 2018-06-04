using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductCategoryMapper
	{
		public virtual BOProductCategory MapModelToBO(
			int productCategoryID,
			ApiProductCategoryRequestModel model
			)
		{
			BOProductCategory BOProductCategory = new BOProductCategory();

			BOProductCategory.SetProperties(
				productCategoryID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return BOProductCategory;
		}

		public virtual ApiProductCategoryResponseModel MapBOToModel(
			BOProductCategory BOProductCategory)
		{
			if (BOProductCategory == null)
			{
				return null;
			}

			var model = new ApiProductCategoryResponseModel();

			model.SetProperties(BOProductCategory.ModifiedDate, BOProductCategory.Name, BOProductCategory.ProductCategoryID, BOProductCategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductCategoryResponseModel> MapBOToModel(
			List<BOProductCategory> BOs)
		{
			List<ApiProductCategoryResponseModel> response = new List<ApiProductCategoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>14e18ee9eb093eaa81255b59f84230b3</Hash>
</Codenesium>*/
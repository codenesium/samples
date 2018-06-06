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
			BOProductCategory boProductCategory = new BOProductCategory();

			boProductCategory.SetProperties(
				productCategoryID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return boProductCategory;
		}

		public virtual ApiProductCategoryResponseModel MapBOToModel(
			BOProductCategory boProductCategory)
		{
			var model = new ApiProductCategoryResponseModel();

			model.SetProperties(boProductCategory.ModifiedDate, boProductCategory.Name, boProductCategory.ProductCategoryID, boProductCategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductCategoryResponseModel> MapBOToModel(
			List<BOProductCategory> items)
		{
			List<ApiProductCategoryResponseModel> response = new List<ApiProductCategoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a20cdcff62f28322ef0d0f230e595b11</Hash>
</Codenesium>*/
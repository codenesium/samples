using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductCategoryMapper
	{
		public virtual DTOProductCategory MapModelToDTO(
			int productCategoryID,
			ApiProductCategoryRequestModel model
			)
		{
			DTOProductCategory dtoProductCategory = new DTOProductCategory();

			dtoProductCategory.SetProperties(
				productCategoryID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return dtoProductCategory;
		}

		public virtual ApiProductCategoryResponseModel MapDTOToModel(
			DTOProductCategory dtoProductCategory)
		{
			if (dtoProductCategory == null)
			{
				return null;
			}

			var model = new ApiProductCategoryResponseModel();

			model.SetProperties(dtoProductCategory.ModifiedDate, dtoProductCategory.Name, dtoProductCategory.ProductCategoryID, dtoProductCategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductCategoryResponseModel> MapDTOToModel(
			List<DTOProductCategory> dtos)
		{
			List<ApiProductCategoryResponseModel> response = new List<ApiProductCategoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6f67a9b808ad28999b9c259fbd1ab58a</Hash>
</Codenesium>*/
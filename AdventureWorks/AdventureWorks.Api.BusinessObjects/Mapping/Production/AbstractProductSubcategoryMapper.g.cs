using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductSubcategoryMapper
	{
		public virtual DTOProductSubcategory MapModelToDTO(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel model
			)
		{
			DTOProductSubcategory dtoProductSubcategory = new DTOProductSubcategory();

			dtoProductSubcategory.SetProperties(
				productSubcategoryID,
				model.ModifiedDate,
				model.Name,
				model.ProductCategoryID,
				model.Rowguid);
			return dtoProductSubcategory;
		}

		public virtual ApiProductSubcategoryResponseModel MapDTOToModel(
			DTOProductSubcategory dtoProductSubcategory)
		{
			if (dtoProductSubcategory == null)
			{
				return null;
			}

			var model = new ApiProductSubcategoryResponseModel();

			model.SetProperties(dtoProductSubcategory.ModifiedDate, dtoProductSubcategory.Name, dtoProductSubcategory.ProductCategoryID, dtoProductSubcategory.ProductSubcategoryID, dtoProductSubcategory.Rowguid);

			return model;
		}

		public virtual List<ApiProductSubcategoryResponseModel> MapDTOToModel(
			List<DTOProductSubcategory> dtos)
		{
			List<ApiProductSubcategoryResponseModel> response = new List<ApiProductSubcategoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eb5b850a8fa108135103851ceb4aacc4</Hash>
</Codenesium>*/
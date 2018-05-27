using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductModelProductDescriptionCultureMapper
	{
		public virtual DTOProductModelProductDescriptionCulture MapModelToDTO(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model
			)
		{
			DTOProductModelProductDescriptionCulture dtoProductModelProductDescriptionCulture = new DTOProductModelProductDescriptionCulture();

			dtoProductModelProductDescriptionCulture.SetProperties(
				productModelID,
				model.CultureID,
				model.ModifiedDate,
				model.ProductDescriptionID);
			return dtoProductModelProductDescriptionCulture;
		}

		public virtual ApiProductModelProductDescriptionCultureResponseModel MapDTOToModel(
			DTOProductModelProductDescriptionCulture dtoProductModelProductDescriptionCulture)
		{
			if (dtoProductModelProductDescriptionCulture == null)
			{
				return null;
			}

			var model = new ApiProductModelProductDescriptionCultureResponseModel();

			model.SetProperties(dtoProductModelProductDescriptionCulture.CultureID, dtoProductModelProductDescriptionCulture.ModifiedDate, dtoProductModelProductDescriptionCulture.ProductDescriptionID, dtoProductModelProductDescriptionCulture.ProductModelID);

			return model;
		}

		public virtual List<ApiProductModelProductDescriptionCultureResponseModel> MapDTOToModel(
			List<DTOProductModelProductDescriptionCulture> dtos)
		{
			List<ApiProductModelProductDescriptionCultureResponseModel> response = new List<ApiProductModelProductDescriptionCultureResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2a028d7e65214a7360f7c0c16fb5936c</Hash>
</Codenesium>*/
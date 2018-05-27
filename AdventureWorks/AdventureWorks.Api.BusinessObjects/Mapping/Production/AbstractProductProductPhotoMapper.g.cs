using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductProductPhotoMapper
	{
		public virtual DTOProductProductPhoto MapModelToDTO(
			int productID,
			ApiProductProductPhotoRequestModel model
			)
		{
			DTOProductProductPhoto dtoProductProductPhoto = new DTOProductProductPhoto();

			dtoProductProductPhoto.SetProperties(
				productID,
				model.ModifiedDate,
				model.Primary,
				model.ProductPhotoID);
			return dtoProductProductPhoto;
		}

		public virtual ApiProductProductPhotoResponseModel MapDTOToModel(
			DTOProductProductPhoto dtoProductProductPhoto)
		{
			if (dtoProductProductPhoto == null)
			{
				return null;
			}

			var model = new ApiProductProductPhotoResponseModel();

			model.SetProperties(dtoProductProductPhoto.ModifiedDate, dtoProductProductPhoto.Primary, dtoProductProductPhoto.ProductID, dtoProductProductPhoto.ProductPhotoID);

			return model;
		}

		public virtual List<ApiProductProductPhotoResponseModel> MapDTOToModel(
			List<DTOProductProductPhoto> dtos)
		{
			List<ApiProductProductPhotoResponseModel> response = new List<ApiProductProductPhotoResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>96f8377339bd6b0ce2bb89ac3d18f6b2</Hash>
</Codenesium>*/
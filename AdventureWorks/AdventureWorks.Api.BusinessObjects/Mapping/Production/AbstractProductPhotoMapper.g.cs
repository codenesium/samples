using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductPhotoMapper
	{
		public virtual DTOProductPhoto MapModelToDTO(
			int productPhotoID,
			ApiProductPhotoRequestModel model
			)
		{
			DTOProductPhoto dtoProductPhoto = new DTOProductPhoto();

			dtoProductPhoto.SetProperties(
				productPhotoID,
				model.LargePhoto,
				model.LargePhotoFileName,
				model.ModifiedDate,
				model.ThumbNailPhoto,
				model.ThumbnailPhotoFileName);
			return dtoProductPhoto;
		}

		public virtual ApiProductPhotoResponseModel MapDTOToModel(
			DTOProductPhoto dtoProductPhoto)
		{
			if (dtoProductPhoto == null)
			{
				return null;
			}

			var model = new ApiProductPhotoResponseModel();

			model.SetProperties(dtoProductPhoto.LargePhoto, dtoProductPhoto.LargePhotoFileName, dtoProductPhoto.ModifiedDate, dtoProductPhoto.ProductPhotoID, dtoProductPhoto.ThumbNailPhoto, dtoProductPhoto.ThumbnailPhotoFileName);

			return model;
		}

		public virtual List<ApiProductPhotoResponseModel> MapDTOToModel(
			List<DTOProductPhoto> dtos)
		{
			List<ApiProductPhotoResponseModel> response = new List<ApiProductPhotoResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9741d6a18126c8580c74c97964fd97b8</Hash>
</Codenesium>*/
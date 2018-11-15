using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductPhotoMapper
	{
		public virtual BOProductPhoto MapModelToBO(
			int productPhotoID,
			ApiProductPhotoServerRequestModel model
			)
		{
			BOProductPhoto boProductPhoto = new BOProductPhoto();
			boProductPhoto.SetProperties(
				productPhotoID,
				model.LargePhoto,
				model.LargePhotoFileName,
				model.ModifiedDate,
				model.ThumbNailPhoto,
				model.ThumbnailPhotoFileName);
			return boProductPhoto;
		}

		public virtual ApiProductPhotoServerResponseModel MapBOToModel(
			BOProductPhoto boProductPhoto)
		{
			var model = new ApiProductPhotoServerResponseModel();

			model.SetProperties(boProductPhoto.ProductPhotoID, boProductPhoto.LargePhoto, boProductPhoto.LargePhotoFileName, boProductPhoto.ModifiedDate, boProductPhoto.ThumbNailPhoto, boProductPhoto.ThumbnailPhotoFileName);

			return model;
		}

		public virtual List<ApiProductPhotoServerResponseModel> MapBOToModel(
			List<BOProductPhoto> items)
		{
			List<ApiProductPhotoServerResponseModel> response = new List<ApiProductPhotoServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>45970536a3f6a7efeba940d6ee0bb1ca</Hash>
</Codenesium>*/
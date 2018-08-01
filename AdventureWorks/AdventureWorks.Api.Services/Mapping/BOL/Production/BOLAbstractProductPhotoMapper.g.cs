using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductPhotoMapper
	{
		public virtual BOProductPhoto MapModelToBO(
			int productPhotoID,
			ApiProductPhotoRequestModel model
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

		public virtual ApiProductPhotoResponseModel MapBOToModel(
			BOProductPhoto boProductPhoto)
		{
			var model = new ApiProductPhotoResponseModel();

			model.SetProperties(boProductPhoto.ProductPhotoID, boProductPhoto.LargePhoto, boProductPhoto.LargePhotoFileName, boProductPhoto.ModifiedDate, boProductPhoto.ThumbNailPhoto, boProductPhoto.ThumbnailPhotoFileName);

			return model;
		}

		public virtual List<ApiProductPhotoResponseModel> MapBOToModel(
			List<BOProductPhoto> items)
		{
			List<ApiProductPhotoResponseModel> response = new List<ApiProductPhotoResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6aa52c17613eec459aa04b1e05b07d6e</Hash>
</Codenesium>*/
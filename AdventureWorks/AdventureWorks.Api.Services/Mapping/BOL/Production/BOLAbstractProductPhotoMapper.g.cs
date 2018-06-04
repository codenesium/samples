using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductPhotoMapper
	{
		public virtual BOProductPhoto MapModelToBO(
			int productPhotoID,
			ApiProductPhotoRequestModel model
			)
		{
			BOProductPhoto BOProductPhoto = new BOProductPhoto();

			BOProductPhoto.SetProperties(
				productPhotoID,
				model.LargePhoto,
				model.LargePhotoFileName,
				model.ModifiedDate,
				model.ThumbNailPhoto,
				model.ThumbnailPhotoFileName);
			return BOProductPhoto;
		}

		public virtual ApiProductPhotoResponseModel MapBOToModel(
			BOProductPhoto BOProductPhoto)
		{
			if (BOProductPhoto == null)
			{
				return null;
			}

			var model = new ApiProductPhotoResponseModel();

			model.SetProperties(BOProductPhoto.LargePhoto, BOProductPhoto.LargePhotoFileName, BOProductPhoto.ModifiedDate, BOProductPhoto.ProductPhotoID, BOProductPhoto.ThumbNailPhoto, BOProductPhoto.ThumbnailPhotoFileName);

			return model;
		}

		public virtual List<ApiProductPhotoResponseModel> MapBOToModel(
			List<BOProductPhoto> BOs)
		{
			List<ApiProductPhotoResponseModel> response = new List<ApiProductPhotoResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7c5a24c3aa9cc8f09b4225bbcbd22e15</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductProductPhotoMapper
	{
		public virtual BOProductProductPhoto MapModelToBO(
			int productID,
			ApiProductProductPhotoRequestModel model
			)
		{
			BOProductProductPhoto boProductProductPhoto = new BOProductProductPhoto();
			boProductProductPhoto.SetProperties(
				productID,
				model.ModifiedDate,
				model.Primary,
				model.ProductPhotoID);
			return boProductProductPhoto;
		}

		public virtual ApiProductProductPhotoResponseModel MapBOToModel(
			BOProductProductPhoto boProductProductPhoto)
		{
			var model = new ApiProductProductPhotoResponseModel();

			model.SetProperties(boProductProductPhoto.ProductID, boProductProductPhoto.ModifiedDate, boProductProductPhoto.Primary, boProductProductPhoto.ProductPhotoID);

			return model;
		}

		public virtual List<ApiProductProductPhotoResponseModel> MapBOToModel(
			List<BOProductProductPhoto> items)
		{
			List<ApiProductProductPhotoResponseModel> response = new List<ApiProductProductPhotoResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>12658bf786462237fb3f41dd681559c9</Hash>
</Codenesium>*/
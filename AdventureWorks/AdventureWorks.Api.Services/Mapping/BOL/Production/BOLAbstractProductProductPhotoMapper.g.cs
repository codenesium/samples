using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductProductPhotoMapper
	{
		public virtual BOProductProductPhoto MapModelToBO(
			int productID,
			ApiProductProductPhotoRequestModel model
			)
		{
			BOProductProductPhoto BOProductProductPhoto = new BOProductProductPhoto();

			BOProductProductPhoto.SetProperties(
				productID,
				model.ModifiedDate,
				model.Primary,
				model.ProductPhotoID);
			return BOProductProductPhoto;
		}

		public virtual ApiProductProductPhotoResponseModel MapBOToModel(
			BOProductProductPhoto BOProductProductPhoto)
		{
			if (BOProductProductPhoto == null)
			{
				return null;
			}

			var model = new ApiProductProductPhotoResponseModel();

			model.SetProperties(BOProductProductPhoto.ModifiedDate, BOProductProductPhoto.Primary, BOProductProductPhoto.ProductID, BOProductProductPhoto.ProductPhotoID);

			return model;
		}

		public virtual List<ApiProductProductPhotoResponseModel> MapBOToModel(
			List<BOProductProductPhoto> BOs)
		{
			List<ApiProductProductPhotoResponseModel> response = new List<ApiProductProductPhotoResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1ce0798e689cee9ff177463e75263d59</Hash>
</Codenesium>*/
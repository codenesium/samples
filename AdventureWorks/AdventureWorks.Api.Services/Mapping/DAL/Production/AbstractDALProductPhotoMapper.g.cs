using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductPhotoMapper
	{
		public virtual ProductPhoto MapModelToBO(
			int productPhotoID,
			ApiProductPhotoServerRequestModel model
			)
		{
			ProductPhoto item = new ProductPhoto();
			item.SetProperties(
				productPhotoID,
				model.LargePhoto,
				model.LargePhotoFileName,
				model.ModifiedDate,
				model.ThumbNailPhoto,
				model.ThumbnailPhotoFileName);
			return item;
		}

		public virtual ApiProductPhotoServerResponseModel MapBOToModel(
			ProductPhoto item)
		{
			var model = new ApiProductPhotoServerResponseModel();

			model.SetProperties(item.ProductPhotoID, item.LargePhoto, item.LargePhotoFileName, item.ModifiedDate, item.ThumbNailPhoto, item.ThumbnailPhotoFileName);

			return model;
		}

		public virtual List<ApiProductPhotoServerResponseModel> MapBOToModel(
			List<ProductPhoto> items)
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
    <Hash>9ec90c1ff7a8fc0eb271678c8a91fcf6</Hash>
</Codenesium>*/
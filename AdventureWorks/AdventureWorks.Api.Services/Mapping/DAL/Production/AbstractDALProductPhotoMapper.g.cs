using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductPhotoMapper
	{
		public virtual ProductPhoto MapModelToEntity(
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

		public virtual ApiProductPhotoServerResponseModel MapEntityToModel(
			ProductPhoto item)
		{
			var model = new ApiProductPhotoServerResponseModel();

			model.SetProperties(item.ProductPhotoID,
			                    item.LargePhoto,
			                    item.LargePhotoFileName,
			                    item.ModifiedDate,
			                    item.ThumbNailPhoto,
			                    item.ThumbnailPhotoFileName);

			return model;
		}

		public virtual List<ApiProductPhotoServerResponseModel> MapEntityToModel(
			List<ProductPhoto> items)
		{
			List<ApiProductPhotoServerResponseModel> response = new List<ApiProductPhotoServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b5b32f3f2a47d9e31040960526d9420c</Hash>
</Codenesium>*/
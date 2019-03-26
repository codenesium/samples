using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductProductPhotoMapper
	{
		public virtual ProductProductPhoto MapModelToEntity(
			int productID,
			ApiProductProductPhotoServerRequestModel model
			)
		{
			ProductProductPhoto item = new ProductProductPhoto();
			item.SetProperties(
				productID,
				model.ModifiedDate,
				model.Primary,
				model.ProductPhotoID);
			return item;
		}

		public virtual ApiProductProductPhotoServerResponseModel MapEntityToModel(
			ProductProductPhoto item)
		{
			var model = new ApiProductProductPhotoServerResponseModel();

			model.SetProperties(item.ProductID,
			                    item.ModifiedDate,
			                    item.Primary,
			                    item.ProductPhotoID);
			if (item.ProductIDNavigation != null)
			{
				var productIDModel = new ApiProductServerResponseModel();
				productIDModel.SetProperties(
					item.ProductIDNavigation.ProductID,
					item.ProductIDNavigation.Color,
					item.ProductIDNavigation.DaysToManufacture,
					item.ProductIDNavigation.DiscontinuedDate,
					item.ProductIDNavigation.FinishedGoodsFlag,
					item.ProductIDNavigation.ListPrice,
					item.ProductIDNavigation.MakeFlag,
					item.ProductIDNavigation.ModifiedDate,
					item.ProductIDNavigation.Name,
					item.ProductIDNavigation.ProductLine,
					item.ProductIDNavigation.ProductModelID,
					item.ProductIDNavigation.ProductNumber,
					item.ProductIDNavigation.ProductSubcategoryID,
					item.ProductIDNavigation.ReorderPoint,
					item.ProductIDNavigation.ReservedClass,
					item.ProductIDNavigation.Rowguid,
					item.ProductIDNavigation.SafetyStockLevel,
					item.ProductIDNavigation.SellEndDate,
					item.ProductIDNavigation.SellStartDate,
					item.ProductIDNavigation.Size,
					item.ProductIDNavigation.SizeUnitMeasureCode,
					item.ProductIDNavigation.StandardCost,
					item.ProductIDNavigation.Style,
					item.ProductIDNavigation.Weight,
					item.ProductIDNavigation.WeightUnitMeasureCode);

				model.SetProductIDNavigation(productIDModel);
			}

			if (item.ProductPhotoIDNavigation != null)
			{
				var productPhotoIDModel = new ApiProductPhotoServerResponseModel();
				productPhotoIDModel.SetProperties(
					item.ProductPhotoIDNavigation.ProductPhotoID,
					item.ProductPhotoIDNavigation.LargePhoto,
					item.ProductPhotoIDNavigation.LargePhotoFileName,
					item.ProductPhotoIDNavigation.ModifiedDate,
					item.ProductPhotoIDNavigation.ThumbNailPhoto,
					item.ProductPhotoIDNavigation.ThumbnailPhotoFileName);

				model.SetProductPhotoIDNavigation(productPhotoIDModel);
			}

			return model;
		}

		public virtual List<ApiProductProductPhotoServerResponseModel> MapEntityToModel(
			List<ProductProductPhoto> items)
		{
			List<ApiProductProductPhotoServerResponseModel> response = new List<ApiProductProductPhotoServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f8390303ecff1b3375e8140864e4ed54</Hash>
</Codenesium>*/
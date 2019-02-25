using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductReviewMapper
	{
		public virtual ProductReview MapModelToEntity(
			int productReviewID,
			ApiProductReviewServerRequestModel model
			)
		{
			ProductReview item = new ProductReview();
			item.SetProperties(
				productReviewID,
				model.Comment,
				model.EmailAddress,
				model.ModifiedDate,
				model.ProductID,
				model.Rating,
				model.ReviewDate,
				model.ReviewerName);
			return item;
		}

		public virtual ApiProductReviewServerResponseModel MapEntityToModel(
			ProductReview item)
		{
			var model = new ApiProductReviewServerResponseModel();

			model.SetProperties(item.ProductReviewID,
			                    item.Comment,
			                    item.EmailAddress,
			                    item.ModifiedDate,
			                    item.ProductID,
			                    item.Rating,
			                    item.ReviewDate,
			                    item.ReviewerName);
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

			return model;
		}

		public virtual List<ApiProductReviewServerResponseModel> MapEntityToModel(
			List<ProductReview> items)
		{
			List<ApiProductReviewServerResponseModel> response = new List<ApiProductReviewServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d47c00b351bc6d2f46c788ed3e4a89cd</Hash>
</Codenesium>*/
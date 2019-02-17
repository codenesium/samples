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
    <Hash>d822f79b8cf393dd9a8a22593ec81ca0</Hash>
</Codenesium>*/
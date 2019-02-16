using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductReviewMapper
	{
		public virtual ProductReview MapModelToBO(
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

		public virtual ApiProductReviewServerResponseModel MapBOToModel(
			ProductReview item)
		{
			var model = new ApiProductReviewServerResponseModel();

			model.SetProperties(item.ProductReviewID, item.Comment, item.EmailAddress, item.ModifiedDate, item.ProductID, item.Rating, item.ReviewDate, item.ReviewerName);

			return model;
		}

		public virtual List<ApiProductReviewServerResponseModel> MapBOToModel(
			List<ProductReview> items)
		{
			List<ApiProductReviewServerResponseModel> response = new List<ApiProductReviewServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5dd96ba31b9c7993d68d260a6cbd89db</Hash>
</Codenesium>*/
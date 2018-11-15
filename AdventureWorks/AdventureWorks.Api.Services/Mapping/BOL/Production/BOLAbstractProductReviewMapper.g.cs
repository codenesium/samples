using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductReviewMapper
	{
		public virtual BOProductReview MapModelToBO(
			int productReviewID,
			ApiProductReviewServerRequestModel model
			)
		{
			BOProductReview boProductReview = new BOProductReview();
			boProductReview.SetProperties(
				productReviewID,
				model.Comment,
				model.EmailAddress,
				model.ModifiedDate,
				model.ProductID,
				model.Rating,
				model.ReviewDate,
				model.ReviewerName);
			return boProductReview;
		}

		public virtual ApiProductReviewServerResponseModel MapBOToModel(
			BOProductReview boProductReview)
		{
			var model = new ApiProductReviewServerResponseModel();

			model.SetProperties(boProductReview.ProductReviewID, boProductReview.Comment, boProductReview.EmailAddress, boProductReview.ModifiedDate, boProductReview.ProductID, boProductReview.Rating, boProductReview.ReviewDate, boProductReview.ReviewerName);

			return model;
		}

		public virtual List<ApiProductReviewServerResponseModel> MapBOToModel(
			List<BOProductReview> items)
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
    <Hash>be0c93df2c7472126787612c2663f296</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductReviewMapper
	{
		public virtual BOProductReview MapModelToBO(
			int productReviewID,
			ApiProductReviewRequestModel model
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

		public virtual ApiProductReviewResponseModel MapBOToModel(
			BOProductReview boProductReview)
		{
			var model = new ApiProductReviewResponseModel();

			model.SetProperties(boProductReview.ProductReviewID, boProductReview.Comment, boProductReview.EmailAddress, boProductReview.ModifiedDate, boProductReview.ProductID, boProductReview.Rating, boProductReview.ReviewDate, boProductReview.ReviewerName);

			return model;
		}

		public virtual List<ApiProductReviewResponseModel> MapBOToModel(
			List<BOProductReview> items)
		{
			List<ApiProductReviewResponseModel> response = new List<ApiProductReviewResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ff165c6604d8fc85775a0e1441e86c8c</Hash>
</Codenesium>*/
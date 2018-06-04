using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductReviewMapper
	{
		public virtual BOProductReview MapModelToBO(
			int productReviewID,
			ApiProductReviewRequestModel model
			)
		{
			BOProductReview BOProductReview = new BOProductReview();

			BOProductReview.SetProperties(
				productReviewID,
				model.Comments,
				model.EmailAddress,
				model.ModifiedDate,
				model.ProductID,
				model.Rating,
				model.ReviewDate,
				model.ReviewerName);
			return BOProductReview;
		}

		public virtual ApiProductReviewResponseModel MapBOToModel(
			BOProductReview BOProductReview)
		{
			if (BOProductReview == null)
			{
				return null;
			}

			var model = new ApiProductReviewResponseModel();

			model.SetProperties(BOProductReview.Comments, BOProductReview.EmailAddress, BOProductReview.ModifiedDate, BOProductReview.ProductID, BOProductReview.ProductReviewID, BOProductReview.Rating, BOProductReview.ReviewDate, BOProductReview.ReviewerName);

			return model;
		}

		public virtual List<ApiProductReviewResponseModel> MapBOToModel(
			List<BOProductReview> BOs)
		{
			List<ApiProductReviewResponseModel> response = new List<ApiProductReviewResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c4876f871bc5c59d6bf5d593b14ede49</Hash>
</Codenesium>*/
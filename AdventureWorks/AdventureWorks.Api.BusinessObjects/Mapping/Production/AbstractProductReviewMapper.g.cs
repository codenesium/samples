using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductReviewMapper
	{
		public virtual DTOProductReview MapModelToDTO(
			int productReviewID,
			ApiProductReviewRequestModel model
			)
		{
			DTOProductReview dtoProductReview = new DTOProductReview();

			dtoProductReview.SetProperties(
				productReviewID,
				model.Comments,
				model.EmailAddress,
				model.ModifiedDate,
				model.ProductID,
				model.Rating,
				model.ReviewDate,
				model.ReviewerName);
			return dtoProductReview;
		}

		public virtual ApiProductReviewResponseModel MapDTOToModel(
			DTOProductReview dtoProductReview)
		{
			if (dtoProductReview == null)
			{
				return null;
			}

			var model = new ApiProductReviewResponseModel();

			model.SetProperties(dtoProductReview.Comments, dtoProductReview.EmailAddress, dtoProductReview.ModifiedDate, dtoProductReview.ProductID, dtoProductReview.ProductReviewID, dtoProductReview.Rating, dtoProductReview.ReviewDate, dtoProductReview.ReviewerName);

			return model;
		}

		public virtual List<ApiProductReviewResponseModel> MapDTOToModel(
			List<DTOProductReview> dtos)
		{
			List<ApiProductReviewResponseModel> response = new List<ApiProductReviewResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3f36d4dae260218a27b056cac536a2b4</Hash>
</Codenesium>*/
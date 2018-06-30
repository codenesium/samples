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
                                model.Comments,
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

                        model.SetProperties(boProductReview.ProductReviewID, boProductReview.Comments, boProductReview.EmailAddress, boProductReview.ModifiedDate, boProductReview.ProductID, boProductReview.Rating, boProductReview.ReviewDate, boProductReview.ReviewerName);

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
    <Hash>f99bec2d7745fa5d329ae2fa48c324b6</Hash>
</Codenesium>*/
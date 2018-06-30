using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductReviewModelMapper
        {
                public virtual ApiProductReviewResponseModel MapRequestToResponse(
                        int productReviewID,
                        ApiProductReviewRequestModel request)
                {
                        var response = new ApiProductReviewResponseModel();
                        response.SetProperties(productReviewID,
                                               request.Comments,
                                               request.EmailAddress,
                                               request.ModifiedDate,
                                               request.ProductID,
                                               request.Rating,
                                               request.ReviewDate,
                                               request.ReviewerName);
                        return response;
                }

                public virtual ApiProductReviewRequestModel MapResponseToRequest(
                        ApiProductReviewResponseModel response)
                {
                        var request = new ApiProductReviewRequestModel();
                        request.SetProperties(
                                response.Comments,
                                response.EmailAddress,
                                response.ModifiedDate,
                                response.ProductID,
                                response.Rating,
                                response.ReviewDate,
                                response.ReviewerName);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>5f53108022563e0d9618cca2ea15e2b2</Hash>
</Codenesium>*/
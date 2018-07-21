using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                                               request.Comment,
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
                                response.Comment,
                                response.EmailAddress,
                                response.ModifiedDate,
                                response.ProductID,
                                response.Rating,
                                response.ReviewDate,
                                response.ReviewerName);
                        return request;
                }

                public JsonPatchDocument<ApiProductReviewRequestModel> CreatePatch(ApiProductReviewRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductReviewRequestModel>();
                        patch.Replace(x => x.Comment, model.Comment);
                        patch.Replace(x => x.EmailAddress, model.EmailAddress);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.Rating, model.Rating);
                        patch.Replace(x => x.ReviewDate, model.ReviewDate);
                        patch.Replace(x => x.ReviewerName, model.ReviewerName);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>689855bf424282080578ace70cde862d</Hash>
</Codenesium>*/
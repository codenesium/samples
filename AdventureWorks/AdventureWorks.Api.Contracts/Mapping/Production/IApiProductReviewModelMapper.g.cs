using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductReviewModelMapper
        {
                ApiProductReviewResponseModel MapRequestToResponse(
                        int productReviewID,
                        ApiProductReviewRequestModel request);

                ApiProductReviewRequestModel MapResponseToRequest(
                        ApiProductReviewResponseModel response);

                JsonPatchDocument<ApiProductReviewRequestModel> CreatePatch(ApiProductReviewRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e82cffcab40e367c04ff95b23420537c</Hash>
</Codenesium>*/
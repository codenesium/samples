using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductReviewModelMapper
        {
                ApiProductReviewResponseModel MapRequestToResponse(
                        int productReviewID,
                        ApiProductReviewRequestModel request);

                ApiProductReviewRequestModel MapResponseToRequest(
                        ApiProductReviewResponseModel response);
        }
}

/*<Codenesium>
    <Hash>27a1cb3c1c786b09a78553ec626fd045</Hash>
</Codenesium>*/
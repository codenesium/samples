using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductReviewMapper
        {
                BOProductReview MapModelToBO(
                        int productReviewID,
                        ApiProductReviewRequestModel model);

                ApiProductReviewResponseModel MapBOToModel(
                        BOProductReview boProductReview);

                List<ApiProductReviewResponseModel> MapBOToModel(
                        List<BOProductReview> items);
        }
}

/*<Codenesium>
    <Hash>886281b9a536f6eadac1dea86770bf18</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>9c4ae75ba14436b0c13fe76065db7a77</Hash>
</Codenesium>*/
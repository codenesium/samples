using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductReviewMapper
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
    <Hash>93ffb4fefd78e0e1b8368f92ba356bcb</Hash>
</Codenesium>*/
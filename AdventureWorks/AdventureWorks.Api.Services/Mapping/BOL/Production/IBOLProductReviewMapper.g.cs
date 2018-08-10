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
    <Hash>335634880ac8bf69dc55edee4c6ad58b</Hash>
</Codenesium>*/
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
    <Hash>86b491123e3441b56ac7c956d00fac60</Hash>
</Codenesium>*/
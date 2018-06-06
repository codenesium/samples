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
    <Hash>708a8718d0b72008ae198d14ad8745e9</Hash>
</Codenesium>*/
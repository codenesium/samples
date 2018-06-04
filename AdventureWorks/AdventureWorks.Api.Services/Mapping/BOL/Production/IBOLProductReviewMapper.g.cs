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
			List<BOProductReview> bos);
	}
}

/*<Codenesium>
    <Hash>5f5dcc709e6c6253d0c87097d5fc2146</Hash>
</Codenesium>*/
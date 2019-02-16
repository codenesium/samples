using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductReviewMapper
	{
		ProductReview MapModelToBO(
			int productReviewID,
			ApiProductReviewServerRequestModel model);

		ApiProductReviewServerResponseModel MapBOToModel(
			ProductReview item);

		List<ApiProductReviewServerResponseModel> MapBOToModel(
			List<ProductReview> items);
	}
}

/*<Codenesium>
    <Hash>ec5ef3cf6caabd6ca9364bbcf39c8cdf</Hash>
</Codenesium>*/
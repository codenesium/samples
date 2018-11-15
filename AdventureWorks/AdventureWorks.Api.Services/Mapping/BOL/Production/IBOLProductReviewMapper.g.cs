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
			ApiProductReviewServerRequestModel model);

		ApiProductReviewServerResponseModel MapBOToModel(
			BOProductReview boProductReview);

		List<ApiProductReviewServerResponseModel> MapBOToModel(
			List<BOProductReview> items);
	}
}

/*<Codenesium>
    <Hash>1632db945984de76379c6f390813fd37</Hash>
</Codenesium>*/
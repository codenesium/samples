using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductReviewMapper
	{
		ProductReview MapModelToEntity(
			int productReviewID,
			ApiProductReviewServerRequestModel model);

		ApiProductReviewServerResponseModel MapEntityToModel(
			ProductReview item);

		List<ApiProductReviewServerResponseModel> MapEntityToModel(
			List<ProductReview> items);
	}
}

/*<Codenesium>
    <Hash>fcfc77f553481c2613d2bdd3de3df6cf</Hash>
</Codenesium>*/
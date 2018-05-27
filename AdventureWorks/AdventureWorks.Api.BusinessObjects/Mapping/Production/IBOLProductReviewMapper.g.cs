using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductReviewMapper
	{
		DTOProductReview MapModelToDTO(
			int productReviewID,
			ApiProductReviewRequestModel model);

		ApiProductReviewResponseModel MapDTOToModel(
			DTOProductReview dtoProductReview);

		List<ApiProductReviewResponseModel> MapDTOToModel(
			List<DTOProductReview> dtos);
	}
}

/*<Codenesium>
    <Hash>f176500310a233231c2ce220a10f933f</Hash>
</Codenesium>*/
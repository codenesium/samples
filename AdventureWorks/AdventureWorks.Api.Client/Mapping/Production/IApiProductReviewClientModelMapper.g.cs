using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductReviewModelMapper
	{
		ApiProductReviewClientResponseModel MapClientRequestToResponse(
			int productReviewID,
			ApiProductReviewClientRequestModel request);

		ApiProductReviewClientRequestModel MapClientResponseToRequest(
			ApiProductReviewClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0e757c51c0e094a9c73c05a2783807d8</Hash>
</Codenesium>*/
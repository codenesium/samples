using AdventureWorksNS.Api.Contracts;
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
    <Hash>8b609538c8fd9bd32e6b1d08cc36ad62</Hash>
</Codenesium>*/
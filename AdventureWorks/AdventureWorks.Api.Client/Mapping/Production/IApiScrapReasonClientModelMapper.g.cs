using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiScrapReasonModelMapper
	{
		ApiScrapReasonClientResponseModel MapClientRequestToResponse(
			short scrapReasonID,
			ApiScrapReasonClientRequestModel request);

		ApiScrapReasonClientRequestModel MapClientResponseToRequest(
			ApiScrapReasonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a343d48e88a66b1a0118ec49b6342feb</Hash>
</Codenesium>*/
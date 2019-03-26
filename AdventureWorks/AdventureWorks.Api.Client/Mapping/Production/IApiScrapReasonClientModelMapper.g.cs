using AdventureWorksNS.Api.Contracts;
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
    <Hash>9027859b9be65785a9014e7cccb917bd</Hash>
</Codenesium>*/
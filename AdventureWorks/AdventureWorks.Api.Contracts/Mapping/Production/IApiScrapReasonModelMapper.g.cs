using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiScrapReasonModelMapper
	{
		ApiScrapReasonResponseModel MapRequestToResponse(
			short scrapReasonID,
			ApiScrapReasonRequestModel request);

		ApiScrapReasonRequestModel MapResponseToRequest(
			ApiScrapReasonResponseModel response);

		JsonPatchDocument<ApiScrapReasonRequestModel> CreatePatch(ApiScrapReasonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7395c886963356b6ef4a4cdf6adb396c</Hash>
</Codenesium>*/
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
    <Hash>aff74e37b533e06e69116fb790d6a0ec</Hash>
</Codenesium>*/
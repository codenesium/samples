using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiScrapReasonModelMapper
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
    <Hash>a244f33387e1e2e78ab93f6162150e06</Hash>
</Codenesium>*/
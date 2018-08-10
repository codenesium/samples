using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductDescriptionModelMapper
	{
		ApiProductDescriptionResponseModel MapRequestToResponse(
			int productDescriptionID,
			ApiProductDescriptionRequestModel request);

		ApiProductDescriptionRequestModel MapResponseToRequest(
			ApiProductDescriptionResponseModel response);

		JsonPatchDocument<ApiProductDescriptionRequestModel> CreatePatch(ApiProductDescriptionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>eeaab558e7e25f2b3917c71b7f77db9b</Hash>
</Codenesium>*/
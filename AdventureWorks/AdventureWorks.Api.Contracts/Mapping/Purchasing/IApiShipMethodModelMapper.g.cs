using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiShipMethodModelMapper
	{
		ApiShipMethodResponseModel MapRequestToResponse(
			int shipMethodID,
			ApiShipMethodRequestModel request);

		ApiShipMethodRequestModel MapResponseToRequest(
			ApiShipMethodResponseModel response);

		JsonPatchDocument<ApiShipMethodRequestModel> CreatePatch(ApiShipMethodRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a31fa4145b2fe036ea629cfa5eac3447</Hash>
</Codenesium>*/
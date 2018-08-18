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
    <Hash>1010b7231ecd19a7a93433dcf3c6646a</Hash>
</Codenesium>*/
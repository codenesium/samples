using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiShipMethodModelMapper
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
    <Hash>1be280ee942039ca21c9cdddd35f8817</Hash>
</Codenesium>*/
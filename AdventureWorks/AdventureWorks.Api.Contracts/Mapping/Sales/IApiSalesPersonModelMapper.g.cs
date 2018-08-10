using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesPersonModelMapper
	{
		ApiSalesPersonResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiSalesPersonRequestModel request);

		ApiSalesPersonRequestModel MapResponseToRequest(
			ApiSalesPersonResponseModel response);

		JsonPatchDocument<ApiSalesPersonRequestModel> CreatePatch(ApiSalesPersonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7035eecabf28b430b959bfb13134f5b6</Hash>
</Codenesium>*/
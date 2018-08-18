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
    <Hash>877c1e34607aab36ae6e873998a5002f</Hash>
</Codenesium>*/
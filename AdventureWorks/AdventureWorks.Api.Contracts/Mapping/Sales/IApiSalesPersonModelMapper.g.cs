using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesPersonModelMapper
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
    <Hash>d261d65fbc0a8b0a2f4a115e8c0b0e18</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiCustomerModelMapper
	{
		ApiCustomerResponseModel MapRequestToResponse(
			int customerID,
			ApiCustomerRequestModel request);

		ApiCustomerRequestModel MapResponseToRequest(
			ApiCustomerResponseModel response);

		JsonPatchDocument<ApiCustomerRequestModel> CreatePatch(ApiCustomerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>dc990f1f4918d7c4209716c6b910e16c</Hash>
</Codenesium>*/
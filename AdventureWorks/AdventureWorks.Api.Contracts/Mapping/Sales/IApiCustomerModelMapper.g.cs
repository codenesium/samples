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
    <Hash>76a716dbb3de4c61a90614f29d8409e4</Hash>
</Codenesium>*/
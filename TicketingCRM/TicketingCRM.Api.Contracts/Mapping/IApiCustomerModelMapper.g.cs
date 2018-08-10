using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiCustomerModelMapper
	{
		ApiCustomerResponseModel MapRequestToResponse(
			int id,
			ApiCustomerRequestModel request);

		ApiCustomerRequestModel MapResponseToRequest(
			ApiCustomerResponseModel response);

		JsonPatchDocument<ApiCustomerRequestModel> CreatePatch(ApiCustomerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>07aaf6f75306319341af3f85425f4f06</Hash>
</Codenesium>*/
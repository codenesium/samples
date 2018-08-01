using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiCustomerModelMapper
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
    <Hash>1d45d660fef81269835a891c85bcba5e</Hash>
</Codenesium>*/
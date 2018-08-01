using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiSaleTicketsModelMapper
	{
		ApiSaleTicketsResponseModel MapRequestToResponse(
			int id,
			ApiSaleTicketsRequestModel request);

		ApiSaleTicketsRequestModel MapResponseToRequest(
			ApiSaleTicketsResponseModel response);

		JsonPatchDocument<ApiSaleTicketsRequestModel> CreatePatch(ApiSaleTicketsRequestModel model);
	}
}

/*<Codenesium>
    <Hash>987bd0b9bbafc0264183d574ea7e00b5</Hash>
</Codenesium>*/
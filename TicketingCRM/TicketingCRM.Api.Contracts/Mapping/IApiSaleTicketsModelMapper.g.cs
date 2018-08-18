using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiSaleTicketsModelMapper
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
    <Hash>a51d5ea34d522ef7676204b00f249340</Hash>
</Codenesium>*/
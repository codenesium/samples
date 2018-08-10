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
    <Hash>23be2dc1c019b02b5b8e6de38b772955</Hash>
</Codenesium>*/
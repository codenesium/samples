using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiSaleTicketModelMapper
	{
		ApiSaleTicketResponseModel MapRequestToResponse(
			int id,
			ApiSaleTicketRequestModel request);

		ApiSaleTicketRequestModel MapResponseToRequest(
			ApiSaleTicketResponseModel response);

		JsonPatchDocument<ApiSaleTicketRequestModel> CreatePatch(ApiSaleTicketRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5f64d0ad7e1bc0c22da4b483a1901346</Hash>
</Codenesium>*/
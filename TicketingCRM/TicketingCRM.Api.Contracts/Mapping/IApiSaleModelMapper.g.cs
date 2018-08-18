using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiSaleModelMapper
	{
		ApiSaleResponseModel MapRequestToResponse(
			int id,
			ApiSaleRequestModel request);

		ApiSaleRequestModel MapResponseToRequest(
			ApiSaleResponseModel response);

		JsonPatchDocument<ApiSaleRequestModel> CreatePatch(ApiSaleRequestModel model);
	}
}

/*<Codenesium>
    <Hash>51541adf6b4608ff09229d250af0e6a0</Hash>
</Codenesium>*/
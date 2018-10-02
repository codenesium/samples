using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiTransactionStatuModelMapper
	{
		ApiTransactionStatuResponseModel MapRequestToResponse(
			int id,
			ApiTransactionStatuRequestModel request);

		ApiTransactionStatuRequestModel MapResponseToRequest(
			ApiTransactionStatuResponseModel response);

		JsonPatchDocument<ApiTransactionStatuRequestModel> CreatePatch(ApiTransactionStatuRequestModel model);
	}
}

/*<Codenesium>
    <Hash>01bb3720b0f1f55eca442ddd86096115</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiTransactionStatusModelMapper
	{
		ApiTransactionStatusResponseModel MapRequestToResponse(
			int id,
			ApiTransactionStatusRequestModel request);

		ApiTransactionStatusRequestModel MapResponseToRequest(
			ApiTransactionStatusResponseModel response);

		JsonPatchDocument<ApiTransactionStatusRequestModel> CreatePatch(ApiTransactionStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c6eff9fc98afdcdcf9d95014a722b26f</Hash>
</Codenesium>*/
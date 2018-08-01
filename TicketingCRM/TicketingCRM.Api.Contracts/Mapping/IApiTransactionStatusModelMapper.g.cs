using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiTransactionStatusModelMapper
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
    <Hash>8a4bd79c97d554a0e04b71578b4c13ed</Hash>
</Codenesium>*/
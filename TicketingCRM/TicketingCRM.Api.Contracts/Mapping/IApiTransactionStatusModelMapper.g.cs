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
    <Hash>4f377f2ddfeaafda356282823c39b8be</Hash>
</Codenesium>*/
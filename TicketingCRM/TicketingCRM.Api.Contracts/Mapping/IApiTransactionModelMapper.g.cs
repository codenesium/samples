using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiTransactionModelMapper
	{
		ApiTransactionResponseModel MapRequestToResponse(
			int id,
			ApiTransactionRequestModel request);

		ApiTransactionRequestModel MapResponseToRequest(
			ApiTransactionResponseModel response);

		JsonPatchDocument<ApiTransactionRequestModel> CreatePatch(ApiTransactionRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4f595c327b0501553588a174d70e9887</Hash>
</Codenesium>*/
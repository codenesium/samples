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
    <Hash>f66ecbc8f52a9c501db50dfe09d2ca48</Hash>
</Codenesium>*/
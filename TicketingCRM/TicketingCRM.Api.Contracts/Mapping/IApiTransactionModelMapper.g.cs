using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiTransactionModelMapper
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
    <Hash>698c147fc20a6dbcecc280392e4fc7dc</Hash>
</Codenesium>*/
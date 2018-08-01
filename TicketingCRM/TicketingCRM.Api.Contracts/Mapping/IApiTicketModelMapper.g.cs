using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiTicketModelMapper
	{
		ApiTicketResponseModel MapRequestToResponse(
			int id,
			ApiTicketRequestModel request);

		ApiTicketRequestModel MapResponseToRequest(
			ApiTicketResponseModel response);

		JsonPatchDocument<ApiTicketRequestModel> CreatePatch(ApiTicketRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b2e7e77d6bf8517a9dfe512006c24138</Hash>
</Codenesium>*/
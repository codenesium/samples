using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiTicketStatuModelMapper
	{
		ApiTicketStatuResponseModel MapRequestToResponse(
			int id,
			ApiTicketStatuRequestModel request);

		ApiTicketStatuRequestModel MapResponseToRequest(
			ApiTicketStatuResponseModel response);

		JsonPatchDocument<ApiTicketStatuRequestModel> CreatePatch(ApiTicketStatuRequestModel model);
	}
}

/*<Codenesium>
    <Hash>70083e4e318b71d0f1bf5f2ff1f708a2</Hash>
</Codenesium>*/
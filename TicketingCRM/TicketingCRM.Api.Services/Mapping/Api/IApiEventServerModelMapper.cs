using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiEventServerModelMapper
	{
		ApiEventServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventServerRequestModel request);

		ApiEventServerRequestModel MapServerResponseToRequest(
			ApiEventServerResponseModel response);

		ApiEventClientRequestModel MapServerResponseToClientRequest(
			ApiEventServerResponseModel response);

		JsonPatchDocument<ApiEventServerRequestModel> CreatePatch(ApiEventServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7594f0604da0582290d519d42412cee3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
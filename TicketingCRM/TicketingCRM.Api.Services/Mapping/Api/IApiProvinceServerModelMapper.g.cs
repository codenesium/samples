using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiProvinceServerModelMapper
	{
		ApiProvinceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiProvinceServerRequestModel request);

		ApiProvinceServerRequestModel MapServerResponseToRequest(
			ApiProvinceServerResponseModel response);

		ApiProvinceClientRequestModel MapServerResponseToClientRequest(
			ApiProvinceServerResponseModel response);

		JsonPatchDocument<ApiProvinceServerRequestModel> CreatePatch(ApiProvinceServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1d88671b4963c64a59a08473da91b37d</Hash>
</Codenesium>*/
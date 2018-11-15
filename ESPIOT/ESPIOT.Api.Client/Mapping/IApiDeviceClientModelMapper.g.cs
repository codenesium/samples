using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
{
	public partial interface IApiDeviceModelMapper
	{
		ApiDeviceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiDeviceClientRequestModel request);

		ApiDeviceClientRequestModel MapClientResponseToRequest(
			ApiDeviceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>125f5c7c078676d74efcf2482958065e</Hash>
</Codenesium>*/